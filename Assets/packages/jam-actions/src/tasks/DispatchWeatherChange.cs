using UnityEngine;
using Jam.Symbols;
using Jam.Utils;
using System;

namespace Jam.Actions
{
    public class DispatchWeatherRequest : ITask
    {
        public SymbolPhrase phrase;

        public DispatchWeatherRequest(SymbolPhrase phrase)
        { this.phrase = phrase; }

        public void Execute(TaskComplete callback)
        {
            var weatherControl = Scene.FindComponent<WeatherSystem>();
            if (weatherControl == null)
            { throw new Exception("No WeatherSystem found on scene; cannot perform weather transition"); }
            weatherControl.TransitionTo(phrase.weather);
            Debug.Log(string.Format("Execute weather change: {0}", phrase.weather));

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
