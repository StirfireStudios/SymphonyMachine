using UnityEngine;
using Jam.Symbols;
using Jam.Weathers;

namespace Jam.Actions
{
    public class PickWeatherForPhrase : ITask
    {
        public SymbolPhrase phrase;

        public PickWeatherForPhrase(SymbolPhrase phrase)
        { this.phrase = phrase; }

        public void Execute(TaskComplete callback)
        {
            // Find all the matches we can to various weathers
            var match = WeatherUtils.OrderedMatches(phrase);
            var selected = match.Count > 0 ? match[0].weather.weather : Weather.Clear;

            // Update symbol phrase
            phrase.weather = selected;
            phrase.weatherPrefab = WeatherUtils.WeatherPrefab(phrase.weather);

            Debug.Log(string.Format("Pick weather for phrase: {0}", selected));

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
