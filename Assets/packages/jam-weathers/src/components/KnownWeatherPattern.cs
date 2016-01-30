using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Weathers
{
    /// The specifics of a known type of weather
    /// These are used to 'best guess' new weather from a Phrase input
    [AddComponentMenu("Jam/Weather/Known Weather Pattern")]
    public class KnownWeatherPattern : MonoBehaviour
    {
        [Tooltip("The weather id")]
        public Weather weather;

        [Tooltip("The weather details")]
        public SymbolBase detail;
    }
}
