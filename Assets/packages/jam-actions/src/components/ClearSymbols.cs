using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Actions
{
    /// Clear selected symbols from the ui
    [AddComponentMenu("Jam/Actions/Clear Symbols")]
    public class ClearSymbols : ActionBase
    {
        public Symbol symbol;

        [Tooltip("The player to update")]
        public PlayerSymbolState player;

        protected override void Execute()
        {
            if (player == null) { throw new Exception(string.Format("ClearSymbols {0} had no assigned player object", this)); }
            player.ClearPhrase();
        }

        protected override void Step(float dt)
        { Complete(); }
    }
}
