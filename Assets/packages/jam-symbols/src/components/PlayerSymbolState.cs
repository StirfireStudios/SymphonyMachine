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
            // TODO
            Debug.Log("Execute weather change");
        }

        private void UpdateDisplayedSymbols(SymbolPhrase phrase)
        {
            // TODO
            SetSymbolsReadyState(current.Ready);
            Debug.Log("Update displayed symbols");
        }

        private void UpdatePhraseHistory(List<SymbolPhrase> history)
        {
            // TODO
            Debug.Log("Update phrase history");
        }

        /// change the visual state to indicate that the right number of symbols is selected, or not
        private void SetSymbolsReadyState(bool ready) {
            // TODO
            Debug.Log(string.Format("Set ready displayed state to {0}", ready));
        }
    }
}
