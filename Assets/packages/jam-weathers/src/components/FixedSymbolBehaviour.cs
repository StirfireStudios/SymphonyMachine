using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Weathers
{
    /// When we randomly assign meaning to symbols, we will do it in this way:
    ///
    ///   - 1) Shuffle the order of the symbols
    ///   - 2) Assign any FixedSymbolBehaviour
    ///   - 3) Randomize any left overs
    ///
    /// See `RandomizeSymbolStates`.
    [AddComponentMenu("Jam/Weather/Fixed Symbol Behaviour")]
    public class FixedSymbolBehaviour : MonoBehaviour
    {
        [Tooltip("Some description of this type")]
        public string description;

        [Tooltip("The weather details")]
        public SymbolBase detail;
    }
}
