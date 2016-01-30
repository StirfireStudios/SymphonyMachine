using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Actions
{
    /// Clear selected symbols from the ui
    [AddComponentMenu("Jam/Actions/Randomize Symbols")]
    public class RandomizeSymbols : ActionBase
    {
        [Tooltip("The player to update")]
        public PlayerSymbolState player;

        protected override void Execute()
        {
            if (player == null) { throw new Exception(string.Format("RandomizeSymbols {0} had no assigned player object", this)); }
            new RandomizeSymbolStates(player).Execute(null);
        }

        protected override void Step(float dt)
        { Complete(); }
    }
}
