using System.Collections.Generic;
using UnityEngine;
using Jam.Actions;

namespace Jam.Symbols
{
    /// History state object
    [System.Serializable]
    public class PlayerHistory
    {
        /// The set of past symbol states
        public List<SymbolPhrase> history = new List<SymbolPhrase>();

        [Tooltip("Number of history items to display")]
        public int historySize = 8;

        [Tooltip("The border around each history item")]
        public float historyBorderSize = 1f;

        [Tooltip("Width of the history panel")]
        public float historyWidth = 5f;

        [Tooltip("Height of the history panel")]
        public float historyHeight = 4f;

        [Tooltip("Plane that defines where to layout history items")]
        public GameObject historyDisplay;
    }

    /// Player selected state
    [System.Serializable]
    public class PlayerSelectSlots
    {
        [Tooltip("First selected symbol slot")]
        public GameObject slot1;

        [Tooltip("Second selected symbol slot")]
        public GameObject slot2;

        [Tooltip("Third selected symbol slot")]
        public GameObject slot3;
    }

    /// Player debugging stuff
    [System.Serializable]
    public class PlayerDebugState
    {
        [Tooltip("Enable console log messages to debug weather choice")]
        public bool weatherChoices;
    }

    /// Player symbols config stuff
    [System.Serializable]
    public class PlayerSymbolConfigState
    {
        [Tooltip("The base color for currently selected symbols")]
        public Color selectedColor;

        [Tooltip("The base color for currently not selected symbols")]
        public Color idleColor;

        [Tooltip("The 'ready' button particle emitter")]
        public ParticleSystem readyNotice;

        [Tooltip("The 'active' particle emitter")]
        public ParticleSystem activeNotice;

        // TODO: Remove this and use dynamic colors
        public Color glowColor;
    }

    /// State of symbols selected by the player now and in the past
    [AddComponentMenu("Jam/Symbols/Symbol State")]
    public class PlayerSymbolState : MonoBehaviour
    {
        /// The current symbol phrase the player is using
        public SymbolPhrase current = new SymbolPhrase();

        /// History state
        public PlayerHistory history;

        /// Slot state
        public PlayerSelectSlots selectSlots;

        /// Symbols on the tower
        public PlayerSymbolConfigState symbolConfig;

        /// Debugging...
        public PlayerDebugState debug;

        /// Push a symbol into the current symbol phrase
        public bool AddSymbol(Symbol symbol)
        {
            var rtn = current.Add(symbol);
            UpdateDisplayedSymbols(current);
            return rtn;
        }

        /// Get the player defined color to glow with
        public Color GetSymbolColorFor(Symbol symbol)
        {
            // TODO: replace with dynamic colors
            return symbolConfig.glowColor;
        }

        /// Clear selected symbols in the current phrase
        public void ClearPhrase()
        {
            current = new SymbolPhrase();
            UpdateDisplayedSymbols(current);
        }

        /// Execute a symbol stream
        public bool ExecutePhrase()
        {
            if (!current.Ready)
            {
                Debug.Log("Player tried to run an incomplete symbol, doing nothing");
                return false;
            }

            ExecuteWeather(current);

            if (!history.history.Contains(current))
            {
                history.history.Add(current);
            }
            else
            {
                Debug.Log("NOT REPLACING HISTORY - IT EXISTS!");
            }

            if (history.history.Count > history.historySize)
            { history.history.RemoveAt(0); }
            UpdatePhraseHistory();

            current = new SymbolPhrase();
            UpdateDisplayedSymbols(current);

            return true;
        }

        private void ExecuteWeather(SymbolPhrase phrase)
        {
            new PickWeatherForPhrase(current, debug.weatherChoices).Execute((ip) =>
            {
                SetActiveState(true);
                var self = ip as PickWeatherForPhrase;
                if ((self != null) && (self.selected != null))
                {
                    /// Push new state to weather.
                    new UpdatePlantsWithNewWeather(self.selected).Execute(null);
                }
                new DispatchWeatherRequest(current).Execute(null);
            });
        }

        private void UpdateDisplayedSymbols(SymbolPhrase phras0, bool init = false)
        {
            new UpdateSymbolDisplayStates(current, this, init).Execute(null);
            SetSymbolsReadyState(current.Ready);
        }

        private void UpdatePhraseHistory()
        {
            new UpdatePhraseHistory(this).Execute(null);
        }

        /// change the visual state to indicate that the right number of symbols is selected, or not
        private void SetSymbolsReadyState(bool ready)
        {
            new UpdateSymbolsReadyState(ready, this).Execute(null);
        }

        /// Set the 'active' state of the central thingo
        private void SetActiveState(bool active)
        {
            if (symbolConfig.activeNotice != null)
            {
                var emitter = symbolConfig.activeNotice.emission;
                emitter.enabled = false;
                if (active)
                {
                    emitter.enabled = true;
                    symbolConfig.activeNotice.Stop();
                    symbolConfig.activeNotice.Clear();
                    symbolConfig.activeNotice.Play();
                }
            }
        }

        /// Go~
        public void Start()
        {
            UpdateDisplayedSymbols(current, true);
            SetActiveState(false);
        }
    }
}
