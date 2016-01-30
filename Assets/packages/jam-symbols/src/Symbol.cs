using System;
using UnityEngine;

namespace Jam.Symbols
{
    /// A single symbol input value
    [Serializable]
    public class Symbol
    {
        [Tooltip("Humidity in the range -1 to 1 for this symbol")]
        public float humidity;

        [Tooltip("Temperature in the range -1 to 1 for this symbol")]
        public float temperature;

        [Tooltip("Wind in the range -1 to 1 for this symbol")]
        public float wind;
    }
}
