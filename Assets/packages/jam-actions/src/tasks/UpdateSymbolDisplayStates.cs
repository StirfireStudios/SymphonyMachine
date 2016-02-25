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

        public PlayerSymbolState player;

        public bool setInitState = false;

        public UpdateSymbolDisplayStates(SymbolPhrase phrase, PlayerSymbolState player, bool init = false)
        {
            this.phrase = phrase;
            this.slots = player.selectSlots;
            this.player = player;
            this.setInitState = init;
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
                    if (symbol.symbolPrefab == null)
                    {
                        Debug.LogError(string.Format("Warning: Symbol {0} does not have a prefab assigned forward it's symbol", symbol));
                    }
                    else
                    {
                        Scene.Spawn(symbol.symbolPrefab).Then((gp) =>
                        {
                            gp.transform.position = parent.transform.position;

                            var rotation = parent.transform.rotation;
                            gp.transform.rotation = rotation;
                            gp.transform.localScale = new Vector3(0.12f, 0.12f, 0.12f);

                            gp.AddComponent<SlotMarker>();
                            symbol.SetHighlightState(gp, true, player);
                        });
                    }
                }
                offset += 1;
            }

            // Find all SelectSymbol components and update their display state
            foreach (var target in Scene.FindComponents<SelectSymbol>())
            {
                var item = target as SelectSymbol;
                item.currentlyHighlighted = phrase.Has(item.symbol);
                item.symbol.SetGlowColor(target.gameObject, player.GetSymbolColorFor(item.symbol));
                if (setInitState)
                {
                    item.symbol.SetHighlightState(target.gameObject, false, player);
                }
            }

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
