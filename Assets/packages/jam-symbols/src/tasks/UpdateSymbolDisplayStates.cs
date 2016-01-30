using UnityEngine;
using Jam.Actions;

namespace Jam.Symbols
{
    public class UpdateSymbolDisplayStates : ITask
    {
        public SymbolPhrase phrase;

        public UpdateSymbolDisplayStates(SymbolPhrase phrase)
        { this.phrase = phrase; }

        public void Execute(TaskComplete callback)
        {
            // Find all SelectSymbol components and update their display state
            foreach (var target in Scene.FindComponents<SelectSymbol>())
            {
                var item = target as SelectSymbol;
                item.currentlyHighlighted = phrase.Has(item.symbol);
            }

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
