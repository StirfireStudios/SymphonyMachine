using UnityEngine;
using System.Collections.Generic;

namespace Jam.Symbols
{
    public class UpdatePhraseHistory : ITask
    {
        public List<SymbolPhrase> history;

        public UpdatePhraseHistory(List<SymbolPhrase> history)
        { this.history = history; }

        public void Execute(TaskComplete callback)
        {
            // Push the history into the display?
            // TODO
            Debug.Log(string.Format("Update history with {0} items", history.Count));

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
