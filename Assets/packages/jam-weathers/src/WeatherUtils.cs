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
            if (rtn == null)
            {
                throw new Exception(string.Format("No WeatherSymbolBinding found for weather id {0}", id));
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
            return rtn;
        }

    }
}
