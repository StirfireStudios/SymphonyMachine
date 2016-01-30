using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Actions
{
    /// Clear selected symbols from the ui
    [AddComponentMenu("Jam/Actions/Run Symbols")]
    public class RunSymbols : ActionBase
    {
        public Symbol symbol;

        [Tooltip("The player to update")]
        public PlayerSymbolState player;

        protected override void Execute()
        {
            if (player == null) { throw new Exception(string.Format("RunSymbols {0} had no assigned player object", this)); }
            player.ExecutePhrase();
        }

        protected override void Step(float dt)
        { Complete(); }
    }
}
