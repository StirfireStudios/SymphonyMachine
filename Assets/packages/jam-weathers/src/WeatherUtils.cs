using System.Collections.Generic;
using UnityEngine;
using Jam.Symbols;
using Jam.Utils;
using System;
using System.Linq;
using Weather;

namespace Jam.Weathers
{
    /// Weather utils
    public class WeatherUtils
    {
        /// Get the prefab symbol for a weather id
        public static GameObject WeatherPrefab(WeatherId id)
        {
            GameObject rtn = null;
            foreach (var cp in Scene.FindComponents<WeatherSymbolBinding>())
            {
                if (cp.weatherId == id)
                {
                    rtn = cp.weatherPrefab;
                }
            }
            return rtn;
        }

        /// Return the ambient sound for a weatherId this is set on the associated WeatherSymbolBinding
        public static AudioClip AmbientSoundFor(WeatherId id)
        {
            AudioClip rtn = null;
            foreach (var cp in Scene.FindComponents<WeatherSymbolBinding>())
            {
                if (cp.weatherId == id)
                {
                    rtn = cp.ambientSound;
                }
            }
            return rtn;
        }

        /// Return a sorted by best-match list of WeatherDelta's
        public static List<WeatherDelta> OrderedMatches(SymbolPhrase phrase)
        {
            var rtn = new List<WeatherDelta>();
            foreach (var pattern in Scene.FindComponents<KnownWeatherPattern>())
            {
                var match = new WeatherDelta(phrase, pattern);
                rtn.Add(match);
            }
            rtn = rtn.OrderBy(o => o.match).ToList();
            rtn.Reverse();
            return rtn;
        }

        /// Find all the weather that we can from the current scene
        public static List<KnownWeatherPattern> KnownWeather()
        {
            return Scene.FindComponents<KnownWeatherPattern>();
        }
    }
}
