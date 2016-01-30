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
                UpdatePhraseHistory(history);

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

        private void UpdatePhraseHistory(List<SymbolPhrase> history)
        {
            new UpdatePhraseHistory(history).Execute(null);
        }

        /// change the visual state to indicate that the right number of symbols is selected, or not
        private void SetSymbolsReadyState(bool ready)
        {
            new UpdateSymbolsReadyState(ready).Execute(null);
        }
    }
}
