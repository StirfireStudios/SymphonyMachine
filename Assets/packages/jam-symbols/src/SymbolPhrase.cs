using System;
using System.Collections.Generic;
using UnityEngine;
using Weather;

namespace Jam.Symbols
{
    /// A set of symbols the player has picked
    [Serializable]
    public class SymbolPhrase
    {
        private const int PhraseLength = 3;

        public List<Symbol> symbols = new List<Symbol>();

        [Tooltip("The weather this phrase resulted in")]
        public WeatherId weather = WeatherId.FINE;

        [Tooltip("The weather token for this symbol; don't assign this, it's automatically generated")]
        public GameObject weatherPrefab;

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

        /// Return true if the phrase has the given symbol
        public bool Has(Symbol symbol)
        {
            return symbols.Contains(symbol);
        }

        /// Clear this phrase
        public void Clear()
        {
            symbols.Clear();
            weather = WeatherId.FINE;
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
