using UnityEngine;
using System;

namespace Jam.Symbols
{
    /// This is public enumerable for weather to use from the symbols
    /// Get's mapped to the correct type when we dispatch to the weather system.
    public enum Weather
    {
        Unresolved,
        Clear,
        Blizzard,
        Windy
    }

    /// Weather utils
    public class WeatherUtils
    {
        /// Get the prefab symbol for a weather id
        public static GameObject WeatherPrefab(Weather id)
        {
            GameObject rtn = null;
            foreach (var cp in Scene.FindComponents<WeatherSymbolBinding>())
            {
                if (cp.weatherId == id)
                {
                    rtn = cp.weatherPrefab;
                }
            }
            if (rtn == null)
            {
                throw new Exception(string.Format("No WeatherSymbolBinding found for weather id {0}", id));
            }
            return rtn;
        }
    }
}
