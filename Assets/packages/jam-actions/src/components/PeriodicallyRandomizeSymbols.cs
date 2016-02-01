using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Actions
{
    /// Clear selected symbols from the ui
    [AddComponentMenu("Jam/Actions/Periodically Randomize Symbols")]
    public class PeriodicallyRandomizeSymbols : MonoBehaviour
    {
        [Tooltip("The player to update")]
        public PlayerSymbolState player;

        [Tooltip("Update this often")]
        public float internval = 60f;

        [Tooltip("Elapsed time since last update")]
        public float elapsed = 0f;

        [Tooltip("Disable this...")]
        public bool disabled = false;

        public void Start()
        {
            new RandomizeSymbolStates(player).Execute(null);
        }

        public void Update()
        {
            if (!disabled)
            {
                elapsed += Time.deltaTime;
                if (elapsed > internval)
                {
                    elapsed = 0f;
                    new RandomizeSymbolStates(player).Execute(null);
                }
            }
        }
    }
}
