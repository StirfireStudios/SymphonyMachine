using UnityEngine;
using Jam.Actions;

namespace Jam.Symbols
{
    public class DispatchWeatherRequest : ITask
    {
        public SymbolPhrase phrase;

        public DispatchWeatherRequest(SymbolPhrase phrase)
        { this.phrase = phrase; }

        public void Execute(TaskComplete callback)
        {
            // TODO: Something smart here.
            Debug.Log("Execute weather change");

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
