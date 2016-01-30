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

        public UpdatePhraseHistory(PlayerSymbolState player)
        {
            historySize = player.historySize;
            history = player.history;
            historyContainer = player.historyDisplay;
            historyOffset = player.historyLineSpace;
        }

        public void Execute(TaskComplete callback)
        {
            // Push the history into the display?
            DeleteOldHistory();
            var offset = 0;
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
            int numChildren = historyContainer.transform.childCount;
            for (int i = 0; i < numChildren; ++i)
            {
                var child = historyContainer.transform.GetChild(i);
                child.transform.parent = null;
                GameObject.Destroy(child);
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
            { gp.transform.parent = historyContainer.transform; }

            // Apply layout
            var layout = new LinearLayout(historyContainer, historyOffset * offset);
            LayoutManager.ApplyLayout(layout, targets);
        }
    }
}
