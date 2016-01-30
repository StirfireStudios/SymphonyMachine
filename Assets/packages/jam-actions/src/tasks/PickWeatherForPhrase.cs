using UnityEngine;
using Jam.Symbols;

namespace Jam.Actions
{
    public class PickWeatherForPhrase : ITask
    {
        public SymbolPhrase phrase;

        public PickWeatherForPhrase(SymbolPhrase phrase)
        { this.phrase = phrase; }

        public void Execute(TaskComplete callback)
        {
            // TODO: Something smart here.
            var selected = Weather.Clear;

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
