using System.Collections.Generic;
using UnityEngine;

namespace Jam.Symbols
{
    /// State of symbols selected by the player now and in the past
    [AddComponentMenu("Jam/Symbols/Weather Symbol Binding")]
    public class WeatherSymbolBinding : MonoBehaviour
    {
        [Tooltip("The prefab associate with this weather id")]
        public GameObject weatherPrefab;

        [Tooltip("The weather id")]
        public Weather weatherId;
    }
}
