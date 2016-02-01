using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Actions
{
    /// Pick a symbol from the UI
    [AddComponentMenu("Jam/Actions/Select Symbol")]
    public class SelectSymbol : ActionBase
    {
        public Symbol symbol;

        [Tooltip("The player to update when this symbol is selected")]
        public PlayerSymbolState player;

        [Tooltip("Is this symbol current selected?")]
        public bool currentlyHighlighted = false;
        private bool highlightState = false;

        public new void Update()
        {
            UpdateActionBase();
            if (currentlyHighlighted != highlightState)
            {
                SetHighlightState(gameObject, currentlyHighlighted);
                highlightState = currentlyHighlighted;
            }
        }

        protected override void Execute()
        {
            if (player == null) { throw new Exception(string.Format("SelectSymbol {0} had no assigned player object", this)); }
            if (!currentlyHighlighted)
            {
                if (player.AddSymbol(symbol))
                {
                    currentlyHighlighted = true;
                }
            }
        }

        protected override void Step(float dt)
        { Complete(); }

        /// change the visual state of the symbol object to be highlighted somehow
        private void SetHighlightState(GameObject target, bool active)
        {
            // TODO
            Debug.Log(string.Format("Set highlighted state to {0}", active));
        }

    }
}
