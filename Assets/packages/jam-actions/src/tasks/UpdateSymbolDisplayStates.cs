using UnityEngine;
using Jam.Actions;
using Jam.Utils;
using Jam.Symbols;

namespace Jam.Actions
{
    /// Update the state of all the symbols, including the console.
    public class UpdateSymbolDisplayStates : ITask
    {
        public SymbolPhrase phrase;

        public PlayerSelectSlots slots;

        public UpdateSymbolDisplayStates(SymbolPhrase phrase, PlayerSymbolState player)
        {
            this.phrase = phrase;
            this.slots = player.selectSlots;
        }

        public void Execute(TaskComplete callback)
        {
            // Destroy old markers
            foreach (var slot in Scene.FindComponents<SlotMarker>())
            { GameObject.Destroy(slot.gameObject); }

            // Add currently selected
            var offset = 0;
            foreach (var symbol in phrase.symbols)
            {
                GameObject parent = null;
                switch (offset)
                {
                    case 0:
                        parent = slots.slot1;
                        break;
                    case 1:
                        parent = slots.slot2;
                        break;
                    case 2:
                        parent = slots.slot3;
                        break;
                }
                if (parent != null)
                {
                    Scene.Spawn(symbol.symbolPrefab).Then((gp) =>
                    {
                        gp.transform.position = parent.transform.position;

                        var rotation = parent.transform.rotation;
                        rotation *= Quaternion.Euler(parent.transform.forward * 90f);
                        gp.transform.rotation = rotation;

                        gp.AddComponent<SlotMarker>();
                    });
                }
                offset += 1;
            }

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
