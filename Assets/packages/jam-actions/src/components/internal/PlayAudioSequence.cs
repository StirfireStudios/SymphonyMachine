using System.Collections.Generic;
using UnityEngine;
using Jam.Utils;

namespace Jam.Actions
{
    /// You could just yeild from a coroutine instead, but this is a little
    /// bit more flexible. usage:
    ///
    ///   var player = AddComponent<PlayAudioSequence>();
    ///   player.audio = myAudioSource;
    ///   player.AddClip(myClip);
    ///   player.AddClips(myClips);
    ///
    /// Notice the component removes itself when it runs out of clips to play.
    [AddComponentMenu("")]
    public class PlayAudioSequence : MonoBehaviour
    {
        /// Set of clips to play
        private List<AudioClip> audioClips = new List<AudioClip>();

        /// The audio source to play on
        public AudioSource audio;

        public RealSpace3D.RealSpace3D_AudioSource audio3d;

        /// Sometimes audioClips last for ages because of their crazy fade out
        /// If any playing clip lasts longer than this, cut it off and start
        /// the next one. -1 = ignore
        public float maxPlaytime = -1f;

        private float elapsed;

        /// Add a single clip
        public void AddClip(AudioClip clip)
        {
            audioClips.Add(clip);
        }

        /// Add a sequence of clips
        public void AddClips(IEnumerable<AudioClip> clips)
        {
            audioClips.AddRange(clips);
        }

        public void NextClip()
        {
            if (audioClips.Count > 0)
            {
                var instance = audioClips[0];
                audioClips.RemoveAt(0);
                audio3d.rs3d_LoadAudioClip(instance, 0);
                audio3d.rs3d_PlaySound();
//                audio.PlayOneShot(instance);
                Debug.Log("Play sequence: " + instance);
                elapsed = 0f;
            }
        }

        public void Update()
        {
            if (audioClips.Count == 0)
            {
                GameObject.Destroy(this);
            }
            else
            {
                if (audio3d != null)
                {
                    if (!audio3d.rs3d_IsPlaying(0))
                    {
                        NextClip();
                    }
                    else
                    {
                        elapsed += Time.deltaTime;
                        if ((maxPlaytime > 0f) && (elapsed > maxPlaytime))
                        {
                            NextClip();
                        }
                    }
                }
            }
        }
    }
}
