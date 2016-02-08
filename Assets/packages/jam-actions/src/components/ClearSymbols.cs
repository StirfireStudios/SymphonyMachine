using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Actions
{
    /// Clear selected symbols from the ui
    [AddComponentMenu("Jam/Actions/Clear Symbols")]
    public class ClearSymbols : ActionBase
    {
        [Tooltip("The player to update")]
        public PlayerSymbolState player;

        [Tooltip("The notice sound for this event")]
        public AudioClip notice;

        protected override void Execute()
        {
            if (player == null) { throw new Exception(string.Format("ClearSymbols {0} had no assigned player object", this)); }
            player.ClearPhrase();

            // Play sound
            var audio = gameObject.GetComponent<AudioSource>();
            if ((audio != null) && (notice != null))
            { audio.PlayOneShot(notice); }
        }

        protected override void Step(float dt)
        { Complete(); }
    }
}
