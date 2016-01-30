using UnityEngine;
using Jam.Symbols;
using Jam.Utils;
using Jam.Weathers;
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
            // Change weather
            var weatherControl = Scene.FindComponent<WeatherSystem>();
            if (weatherControl != null)
            {
                weatherControl.TransitionTo(phrase.weather);
            }
            else { Debug.LogError("Missing WeatherSystem on scene"); }

            // Apply some ambient audio if there is any
            var ambientController = Scene.FindComponent<AmbienceController>();
            if (ambientController != null)
            {
                var sound = WeatherUtils.AmbientSoundFor(phrase.weather);
                if (sound != null)
                {
                    ambientController.PlaySound(sound);
                }
            }
            else { Debug.LogError("Missing AmbienceController"); }


            Debug.Log(string.Format("Execute weather change: {0}", phrase.weather));

            // Done~
            if (callback != null)
            { callback(this); }
        }
    }
}
