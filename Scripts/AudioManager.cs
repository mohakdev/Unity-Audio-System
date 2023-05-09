using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        public enum SoundTypes
        {
            AudioOne,
            AudioTwo
        }

        [Header("References")]
        public GameObject SoundSFX;
        public SoundClips[] audioList;
        float SFXVolume = 100f;

        //Just your typical singleton pattern.
        public static AudioManager Instance { get; private set; }
        void Start()
        {
            // If there is an instance, and it's not me, delete myself.
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }

            SoundSFX = transform.Find("SoundSFX").gameObject;
        }


        /// <summary>
        /// Simply plays your desired sound
        /// </summary>
        /// <param name="soundType">Select the sound type you wanna play</param>
        public void PlaySound(SoundTypes soundType)
        {
            GameObject soundPlayer = new GameObject("SFX Source");
            soundPlayer.transform.SetParent(SoundSFX.transform);
            AudioSource soundSource = soundPlayer.AddComponent<AudioSource>();
            AudioClip audioClip = GetAudioClip(soundType);
            soundSource.PlayOneShot(audioClip);
        }

        //Helper Methods
        public AudioClip GetAudioClip(SoundTypes soundType)
        {
            foreach(SoundClips soundClip in audioList)
            {
                if (soundClip.soundType.Equals(soundType))
                {
                    return soundClip.audioClip;
                }
            }
            Debug.LogError("No soundtype found");
            return null;
        }

        public AudioSource GetMusicSource()
        {
            return MusicHandler.musicSource;
        }

        public float GetMusicVolume()
        {
            return MusicHandler.musicSource.volume;
        }
        public void SetMusicVolume(float value)
        {
            MusicHandler.musicSource.volume = value;
        }

        public float GetSFXVolume()
        {
            return SFXVolume;
        }
        public void SetSFXVolume(float value)
        {
            SFXVolume = value;
        }
    }
}
