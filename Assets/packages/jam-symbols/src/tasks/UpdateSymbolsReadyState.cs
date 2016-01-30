using UnityEngine;
using System.Collections.Generic;

namespace Jam.Symbols
{
    public class UpdateSymbolsReadyState : ITask
    {
        public bool ready;

        public UpdateSymbolsReadyState(bool ready)
        { this.ready = ready; }

        public void Execute(TaskComplete callback)
        {
            // somehow update the display here?
            // TODO
            Debug.Log(string.Format("Update ready state for action to: {0}", ready));

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
