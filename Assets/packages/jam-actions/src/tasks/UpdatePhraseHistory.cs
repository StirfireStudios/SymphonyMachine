using UnityEngine;
using System.Collections.Generic;
using Jam.Utils.Layout;
using Jam.Utils;
using Jam.Symbols;

namespace Jam.Actions
{
    public class UpdatePhraseHistory : ITask
    {
        public PlayerHistory history;

        public UpdatePhraseHistory(PlayerSymbolState player)
        { this.history = player.history; }

        public void Execute(TaskComplete callback)
        {
            // Push the history into the display?
            DeleteOldHistory();
            var offset = 0;
            var history = new List<SymbolPhrase>();
            history.AddRange(this.history.history);
            history.Reverse();
            foreach (var historyItem in history)
            {
                SpawnHistoryPrefabsAndLayout(historyItem, offset);
                offset += 1;
                if (offset >= this.history.historySize)
                {
                    break;
                }
            }

            Debug.Log(string.Format("Update history with {0} items", history.Count));

            // Done~
            if (callback != null)
            { callback(this); }
        }

        /// Reset history items
        private void DeleteOldHistory()
        {
            // Destroy children
            foreach (var child in Scene.FindComponents<HistoryMarker>())
            {
                child.transform.parent = null;
                GameObject.Destroy(child.gameObject);
            }
        }

        /// Spawn objects and create a layout for the given history item
        private void SpawnHistoryPrefabsAndLayout(SymbolPhrase phrase, int offset)
        {
            var targets = new List<GameObject>();
            foreach (var symbol in phrase.symbols)
            {
                if (symbol.symbolPrefab == null)
                {
                    Debug.LogError(string.Format("Warning: Symbol {0} does not have a prefab assigned forward it's symbol", symbol));
                }
                else
                {
                    Scene.Spawn(symbol.symbolPrefab).Then((op) => targets.Add(op));
                }
            }
            Scene.Spawn(phrase.weatherPrefab).Then((op) => targets.Add(op));

            // assign parent
            foreach (var gp in targets)
            { gp.AddComponent<HistoryMarker>(); }

            // Apply layout
            var layout = new LinearLayout(
              history.historyDisplay,
              history.historyLineSpace * offset,
              history.historyWidth,
              history.historyHeight);
            LayoutManager.ApplyLayout(layout, targets);
        }
    }
}
