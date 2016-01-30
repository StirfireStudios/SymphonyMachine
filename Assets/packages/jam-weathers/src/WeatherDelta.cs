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
            normalized.Normalize();
        }

        /// Calculate delta
        private void Delta()
        {
            match = weather.detail.Delta(normalized);
        }
    }
}
