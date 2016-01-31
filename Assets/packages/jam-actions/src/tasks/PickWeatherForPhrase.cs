using UnityEngine;
using Jam.Symbols;
using Jam.Weathers;
using Weather;

namespace Jam.Actions
{
    public class PickWeatherForPhrase : ITask
    {
        public SymbolPhrase phrase;

        public WeatherDelta selected;

        public PickWeatherForPhrase(SymbolPhrase phrase)
        { this.phrase = phrase; }

        public void Execute(TaskComplete callback)
        {
            // Find all the matches we can to various weathers
            var match = WeatherUtils.OrderedMatches(phrase);

            // Debugging why we picked X
            if (false)
            {
                Debug.Log("found " + match.Count + "matches...");
                foreach (var m in match) { m.Debug(); }
            }

            // Select best match~
            selected = match.Count > 0 ? match[0] : null;
            var selectedId = match.Count > 0 ? match[0].weather.weather : WeatherId.FINE;

            // Update symbol phrase
            phrase.weather = selectedId;
            phrase.weatherPrefab = WeatherUtils.WeatherPrefab(phrase.weather);

            Debug.Log(string.Format("Pick weather for phrase: {0}", selected));

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
