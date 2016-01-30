using UnityEngine;
using Jam.Symbols;
using Jam.Utils;

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
            /// In format: humidity, temperature, wind
            var always = new float[][] {
              new float[] { 0f, 1f, 0f },  // Hot, still
              new float[] { 1f, -1f, 1f }, // Blizzard
              new float[] { 1f, 0f, 0f },  // Rain
              new float[] { 1f, 0f, 1f },  // Storm
            };

            // Apply all then always that we can
            var offset = 0;
            foreach (var required in always)
            {
                if (components.Count > offset)
                {
                    components[offset].symbol.humidity = required[0];
                    components[offset].symbol.temperature = required[1];
                    components[offset].symbol.wind = required[2];
                }
                offset += 1;
            }

            // Do the rest~
            for (var i = always.Length; i < components.Count; ++i)
            { components[i].symbol.Randomize(); }

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
