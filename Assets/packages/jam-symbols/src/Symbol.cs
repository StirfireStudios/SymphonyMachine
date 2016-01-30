using System;
using UnityEngine;

namespace Jam.Symbols
{
    /// A single symbol input value
    [Serializable]
    public class Symbol
    {
        [Tooltip("Humidity in the range 0 to 1 for this symbol")]
        public float humidity;

        [Tooltip("Temperature in the range -1 to 1 for this symbol")]
        public float temperature;

        [Tooltip("Wind in the range 0 to 1 for this symbol")]
        public float wind;

        [Tooltip("The symbol token for this symbol")]
        public GameObject symbolPrefab;

        /// Randomize the value of this symbol
        public void Randomize()
        {
            temperature = Random.Between(-1f, 1f);
            humidity = Random.Between(0f, 1f);
            wind = Random.Between(0f, 1f);
        }
    }
}
