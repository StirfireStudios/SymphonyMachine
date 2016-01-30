using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jam.Symbols
{
    /// A set of symbols the player has picked
    [Serializable]
    public class SymbolPhrase
    {
        private const int PhraseLength = 3;

        public List<Symbol> symbols = new List<Symbol>();

        [Tooltip("The weather this phrase resulted in")]
        public Weather weather = Weather.Unresolved;

        /// Add a symbol to the set
        public bool Add(Symbol symbol)
        {
            if (!Ready)
            {
                Debug.Log("Added a symbol to the phrase");
                symbols.Add(symbol);
                return true;
            }
            Debug.Log("Phrase was already complete, ignored request");
            return false;
        }

        /// Clear this phrase
        public void Clear()
        {
            symbols.Clear();
            weather = Weather.Unresolved;
        }

        /// Is this phrase complete?
        public bool Ready
        {
            get
            {
                return symbols.Count == PhraseLength;
            }
        }

    }
}
