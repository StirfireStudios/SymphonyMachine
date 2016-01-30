using UnityEngine;
using Jam.Actions;

namespace Jam.Symbols
{
    public class PickWeatherForPhrase : ITask
    {
        public SymbolPhrase phrase;

        public PickWeatherForPhrase(SymbolPhrase phrase)
        { this.phrase = phrase; }

        public void Execute(TaskComplete callback)
        {
            // TODO: Something smart here.
            Debug.Log("Pick weather for phrase");

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
