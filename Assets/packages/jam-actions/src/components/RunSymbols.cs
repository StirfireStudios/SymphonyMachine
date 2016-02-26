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

            var audio = gameObject.GetComponent<RealSpace3D.RealSpace3D_AudioSource>();
            if (audio == null)
            {
                Debug.Log("Whoa oh. no audio...");
//                audio = gameObject.AddComponent<RealSpace3D.RealSpace3D_AudioSource>();
            }

            /// Play phrase~
            if (success)
            {
                var audioPlayer = gameObject.AddComponent<PlayAudioSequence>();
                audioPlayer.audio3d = audio;
                
                audioPlayer.maxPlaytime = 1f;

                foreach (var symbol in old.symbols)
                { symbol.AudioClip().Then((ap) => { audioPlayer.AddClip(ap); }); }
                audioPlayer.AddClip(successSound);
            }

            // Eh, don't bother with a player, just play the fail sound
            else
            {
                if (!audio.rs3d_IsPlaying())
                {
                    audio.rs3d_LoadAudioClip(failureSound, 0);
                    audio.rs3d_PlaySound();
                }
            }
        }

        protected override void Step(float dt)
        { Complete(); }
    }
}
