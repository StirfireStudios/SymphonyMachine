using UnityEngine;
using Jam.Symbols;
using Jam.Utils;
using System;

namespace Jam.Weathers
{
    /// Distance between some known weather and a phrase
    public class WeatherDelta
    {
        /// The phrase
        public SymbolPhrase phrase;

        /// The weather
        public KnownWeatherPattern weather;

        /// The argregate score values
        public SymbolBase score;

        /// The normalized score values
        public SymbolBase normalized;

        /// The match weight
        public float match;

        public WeatherDelta(SymbolPhrase phrase, KnownWeatherPattern pattern)
        {
            this.phrase = phrase;
            weather = pattern;
            Aggregate();
            Normalize();
            Delta();
        }

        /// Aggregate score
        private void Aggregate()
        {
            score = new SymbolBase();
            foreach (var sym in phrase.symbols)
            { score.Add(sym); }
        }

        /// Normalize
        private void Normalize() {
            normalized = new SymbolBase();
            normalized.Add(score);
            normalized.Normalize();
        }

        /// Calculate delta
        private void Delta()
        {
            match = 1f - weather.detail.Delta(normalized);
        }

        /// Print the match value
        public void Debug()
        {
            UnityEngine.Debug.Log(string.Format("phrase match to {0} is {1}, with argregate {2} and normalized {3} vs weather {4}",
              weather.weather, match, score.Debug(), normalized.Debug(), weather.detail.Debug()
            ));
        }
    }
}
