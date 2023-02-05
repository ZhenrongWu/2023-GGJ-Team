#nullable enable
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager Instance;
        
        [SerializeField] AudioSource? audioSourceBGM;
        [SerializeField] AudioSource? audioSourceSE;

        private void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            Instance = this;
        }

        private void Start()
        {
            PlayBGM();
        }

        public void PlayBGM()
        {
            audioSourceBGM?.Play();
        }

        public void PlayBGM(AudioClip clip, bool loop)
        {
            if (audioSourceBGM == null)
                return;

            if (audioSourceBGM.isPlaying)
                audioSourceBGM.Stop();
            audioSourceBGM.clip = clip;
            audioSourceBGM.loop = loop;
            audioSourceBGM.Play();
        }

        public void PlayOneShot(AudioClip clip)
        {
            audioSourceSE?.PlayOneShot(clip);
        }
    }
}
