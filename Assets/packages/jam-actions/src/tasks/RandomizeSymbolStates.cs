using UnityEngine;
using Jam.Symbols;
using Jam.Utils;
using Jam.Weathers;

namespace Jam.Actions
{
    /// Run this to reset the states of the symbols
    public class RandomizeSymbolStates : ITask
    {
        PlayerSymbolState player;

        public RandomizeSymbolStates(PlayerSymbolState player)
        { this.player = player; }

        public void Execute(TaskComplete callback)
        {
            player.ClearPhrase();

            // Shuffle components, then make sure at least 1 of each type is present
            // and the rest are all random.
            var components = Scene.FindComponents<SelectSymbol>();
            Jam.Utils.Random.Shuffle(components);

            /// Default symbol states we always expect
            var always = Scene.FindComponents<FixedSymbolBehaviour>();

            // Apply all then always that we can
            var offset = 0;
            foreach (var required in always)
            {
                if (components.Count > offset)
                {
                    components[offset].symbol.humidity = required.detail.humidity;
                    components[offset].symbol.temperature = required.detail.temperature;
                    components[offset].symbol.wind = required.detail.wind;
                }
                offset += 1;
            }

            // Do the rest~
            for (var i = always.Count; i < components.Count; ++i)
            { components[i].symbol.Randomize(); }

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
