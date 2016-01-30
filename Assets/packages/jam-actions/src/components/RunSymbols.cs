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
        AudioSource audio;

        protected override void Execute()
        {
            if (player == null) { throw new Exception(string.Format("RunSymbols {0} had no assigned player object", this)); }
            
            bool success = player.ExecutePhrase();

            if(audio == null)
                audio = gameObject.AddComponent<AudioSource>();

            audio.clip = success ? successSound : failureSound;
            audio.Play();

        }

        protected override void Step(float dt)
        { Complete(); }
    }
}
