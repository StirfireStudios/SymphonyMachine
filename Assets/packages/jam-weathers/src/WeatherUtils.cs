using UnityEngine;
using Jam.Symbols;
using Jam.Utils;
using System;

namespace Jam.Weathers
{
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
