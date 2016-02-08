using UnityEngine;
using System;
using Jam.Symbols;

namespace Jam.Actions
{
    /// Clear selected symbols from the ui
    [AddComponentMenu("Jam/Actions/Run Symbols")]
    public class RunSymbols : ActionBase
    {
        [Tooltip("The player to update")]
        public PlayerSymbolState player;

        public AudioClip successSound;
        public AudioClip failureSound;

        protected override void Execute()
        {
            if (player == null) { throw new Exception(string.Format("RunSymbols {0} had no assigned player object", this)); }

            var old = player.current;
            bool success = player.ExecutePhrase(); // Resets phrase

            var audio = gameObject.GetComponent<AudioSource>();
            if (audio == null)
            {
                audio = gameObject.AddComponent<AudioSource>();
                audio.spatialBlend = 1;
            }

            /// Play phrase~
            if (success)
            {
                var audioPlayer = gameObject.AddComponent<PlayAudioSequence>();
                audioPlayer.audio = audio;
                audioPlayer.maxPlaytime = 1f;

                foreach (var symbol in old.symbols)
                { symbol.AudioClip().Then((ap) => { audioPlayer.AddClip(ap); }); }
                audioPlayer.AddClip(successSound);
            }

            // Eh, don't bother with a player, just play the fail sound
            else
            {
                if (!audio.isPlaying)
                {
                    audio.PlayOneShot(failureSound);
                }
            }
        }

        protected override void Step(float dt)
        { Complete(); }
    }
}
