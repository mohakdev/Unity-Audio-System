using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        [Header("References")]
        public AudioSource MusicSource;
        public GameObject SoundSFX;
        public AudioClip[] audioList;
        public AudioClip[] musicList;
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
            StartCoroutine(PlayMusic());
        }

        //Match these enums to audioList
        public enum SoundTypes
        {
            AudioOne,
            AudioTwo
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
            soundSource.PlayOneShot(Instance.audioList[(int)soundType]);
        }

        IEnumerator PlayMusic()
        {
            if(musicList == null) { yield return null; }

            //Looping throught the musicList
            int k = 0;
            while(k < musicList.Length)
            {
                MusicSource.clip = musicList[k];
                MusicSource.Play();
                yield return new WaitForSeconds(musicList[k].length);
                //If k is the last element of list then repeat
                if (k >= musicList.Length - 1)
                {
                    k = 0;
                    continue;
                }
                k++;
            }
        }

        //Helper Methods

        public AudioSource GetMusicSource()
        {
            return MusicSource;
        }

        public float GetMusicVolume()
        {
            return MusicSource.volume;
        }
        public void SetMusicVolume(float value)
        {
            MusicSource.volume = value;
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
