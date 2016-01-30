using System.Collections.Generic;
using UnityEngine;

namespace Jam.Symbols
{
    /// State of symbols selected by the player now and in the past
    [AddComponentMenu("Jam/Symbols/Symbol State")]
    public class PlayerSymbolState : MonoBehaviour
    {
        /// The current symbol phrase the player is using
        public SymbolPhrase current = new SymbolPhrase();

        /// The set of past symbol states
        public List<SymbolPhrase> history = new List<SymbolPhrase>();

        [Tooltip("Number of history items to display")]
        public int historySize = 4;

        [Tooltip("The vertical space between each line of history")]
        public float historyLineSpace = 1f;

        [Tooltip("Width of the history panel")]
        public float historyWidth = 5f;

        [Tooltip("Height of the history panel")]
        public float historyHeight = 4f;

        [Tooltip("Plane that defines where to layout history items")]
        public GameObject historyDisplay;

        /// Push a symbol into the current symbol phrase
        public bool AddSymbol(Symbol symbol)
        {
            var rtn = current.Add(symbol);
            UpdateDisplayedSymbols(current);
            return rtn;
        }

        /// Clear selected symbols in the current phrase
        public void ClearPhrase()
        {
            current = new SymbolPhrase();
            UpdateDisplayedSymbols(current);
        }

        /// Execute a symbol stream
        public bool ExecutePhrase()
        {
            if (current.Ready)
            {
                ExecuteWeather(current);

                history.Add(current);
                if (history.Count > historySize)
                { history.RemoveAt(0); }
                UpdatePhraseHistory();

                current = new SymbolPhrase();
                UpdateDisplayedSymbols(current);

                return true;
            }
            Debug.Log("Player tried to run an incomplete symbol, doing nothing");
            return false;
        }

        private void ExecuteWeather(SymbolPhrase phrase)
        {
            new PickWeatherForPhrase(current).Execute((ip) =>
            {
                new DispatchWeatherRequest(current).Execute(null);
            });
        }

        private void UpdateDisplayedSymbols(SymbolPhrase phrase)
        {
            new UpdateSymbolDisplayStates(current).Execute(null);
            SetSymbolsReadyState(current.Ready);
        }

        private void UpdatePhraseHistory()
        {
            new UpdatePhraseHistory(this).Execute(null);
        }

        /// change the visual state to indicate that the right number of symbols is selected, or not
        private void SetSymbolsReadyState(bool ready)
        {
            new UpdateSymbolsReadyState(ready).Execute(null);
        }
    }
}
