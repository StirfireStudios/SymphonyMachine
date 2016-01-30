using UnityEngine;
using System.Collections.Generic;
using Jam.Symbols.Layout;

namespace Jam.Symbols
{
    public class UpdatePhraseHistory : ITask
    {
        public List<SymbolPhrase> history;

        public int historySize;

        public GameObject historyContainer;

        public float historyOffset;
        public float historyWidth;
        public float historyHeight;

        public UpdatePhraseHistory(PlayerSymbolState player)
        {
            historySize = player.historySize;
            history = player.history;
            historyContainer = player.historyDisplay;
            historyOffset = player.historyLineSpace;
            historyWidth = player.historyWidth;
            historyHeight = player.historyHeight;
        }

        public void Execute(TaskComplete callback)
        {
            // Push the history into the display?
            DeleteOldHistory();
            var offset = 0;
            var history = new List<SymbolPhrase>();
            history.AddRange(this.history);
            history.Reverse();
            foreach (var historyItem in history)
            {
                SpawnHistoryPrefabsAndLayout(historyItem, offset);
                offset += 1;
                if (offset >= historySize)
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
            { Scene.Spawn(symbol.symbolPrefab).Then((op) => targets.Add(op)); }
            Scene.Spawn(phrase.weatherPrefab).Then((op) => targets.Add(op));

            // assign parent
            foreach (var gp in targets)
            { gp.AddComponent<HistoryMarker>(); }

            // Apply layout
            var layout = new LinearLayout(historyContainer, historyOffset * offset, historyWidth, historyHeight);
            LayoutManager.ApplyLayout(layout, targets);
        }
    }
}
