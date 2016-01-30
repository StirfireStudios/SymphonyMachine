using UnityEngine;
using System;
using Jam.Utils;

namespace Jam.Symbols
{
    /// This is public enumerable for weather to use from the symbols
    /// Get's mapped to the correct type when we dispatch to the weather system.
    public enum Weather
    {
        Unresolved,
        Sunny,
        Blizzard,
        Cloudy,
        Heatwave,
        HeavyRain,
        Rainy,
        Snow,
        Storm,
        Windy
    }
}
