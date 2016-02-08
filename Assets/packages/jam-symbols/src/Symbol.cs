using System;
using UnityEngine;
using Jam.Utils;

namespace Jam.Symbols
{
    /// Base symbol type; used in various places
    [Serializable]
    public class SymbolBase
    {
        [Tooltip("Humidity in the range 0 to 1 for this symbol")]
        public float humidity;

        [Tooltip("Temperature in the range -1 to 1 for this symbol")]
        public float temperature;

        [Tooltip("Wind in the range 0 to 1 for this symbol")]
        public float wind;

        /// Add another symbol to this one
        public void Add(SymbolBase symbol)
        {
            humidity += symbol.humidity;
            temperature += symbol.temperature;
            wind += symbol.wind;
        }

        /// Randomize the value of this symbol
        public void Randomize()
        {
            temperature = Jam.Utils.Random.Between(-1f, 1f);
            humidity = Jam.Utils.Random.Between(0f, 1f);
            wind = Jam.Utils.Random.Between(0f, 1f);
        }

        /// Normalize values internally
        public void Normalize()
        {
            var magnitude = temperature * temperature + humidity * humidity + wind * wind;
            if (magnitude != 0f)
            {
                magnitude = (float)Math.Sqrt((double)magnitude);
                var mult = 1f / magnitude;
                temperature = mult * temperature;
                humidity = mult * humidity;
                wind = mult * wind;
            }
        }

        /// Delta between this symbol and some other one
        /// 0f = no difference
        /// 1f = all totally different
        public float Delta(SymbolBase other)
        {
            var hd = other.humidity - this.humidity;
            var td = Math.Abs(other.temperature - this.temperature) / 2f;
            var wd = other.wind - this.wind;
            return Mathf.Sqrt(hd * hd + td * td + wd * wd);
        }

        /// Return self as vector
        public string Debug()
        {
            return string.Format("H: {0}, T: {1}, W: {2}", humidity, temperature, wind);
        }

        /// Set the glow state
        public void SetGlowColor(GameObject gameObject, Color c)
        {
            var renderer = gameObject.GetComponent<Renderer>();
            renderer.material.SetColor("_GlowColor", c);
        }

        /// change the visual state of the symbol object to be highlighted somehow
        public void SetHighlightState(GameObject gameObject, bool active, PlayerSymbolState player)
        {
            var renderer = gameObject.GetComponent<Renderer>();
            if (active)
            {
                renderer.material.SetColor("_BaseColor", player.symbolConfig.selectedColor);
            }
            else
            {
                renderer.material.SetColor("_BaseColor", player.symbolConfig.idleColor);
            }
        }
    }

    /// A single symbol input value
    [Serializable]
    public class Symbol : SymbolBase
    {
        [Tooltip("The symbol token for this symbol")]
        public GameObject symbolPrefab;

        /// Ouch, messy.
        /// If we ever come back to this code make sure we never assign an
        /// audio clip directly to an audio source, and that we have a master
        /// assignable reference on the symbol config to specify items audio
        /// config.
        public Option<AudioClip> AudioClip()
        {
            if (symbolPrefab != null)
            {
                var audioSource = symbolPrefab.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    var clip = audioSource.clip;
                    if (clip != null)
                    {
                        return Option.Some(clip);
                    }
                }
            }
            return Option.None<AudioClip>();
        }
    }
}
