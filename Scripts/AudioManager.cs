using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.Tools.AudioSystem
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

        //Creating 2 overloads of PlaySound()
        /// <param name="soundType">The sound you want to play</param>
        public void PlayAudio(SoundTypes soundType)
        {
            //Making a new gameobject to add audioSource component in.
            GameObject soundPlayer = new GameObject("SFX Source");
            soundPlayer.transform.SetParent(SoundSFX.transform);
            AudioSource soundSource = soundPlayer.AddComponent<AudioSource>();
            //Playing the sound
            AudioClip audioClip = GetAudioClip(soundType);
            soundSource.PlayOneShot(audioClip);
            //Deleting the soundPlayer
            StartCoroutine(DeleteAudioObject(soundPlayer, audioClip));
        }

        /// <param name="soundType">The sound you want to play</param>
        /// <param name="audioSettings">Settings on which you want your audio to play</param>
        public void PlayAudio(SoundTypes soundType, AudioSettings audioSettings)
        {
            //Making a new gameobject to add audioSource component in.
            GameObject soundPlayer = new GameObject("SFX Source");
            soundPlayer.transform.SetParent(SoundSFX.transform);
            AudioSource soundSource = soundPlayer.AddComponent<AudioSource>();
            //Changing settings according to User
            soundSource.volume = audioSettings.volume;
            soundSource.pitch = audioSettings.pitch;
            //Playing the sound
            AudioClip audioClip = GetAudioClip(soundType);
            soundSource.PlayOneShot(audioClip);
            //Deleting the soundPlayer
            StartCoroutine(DeleteAudioObject(soundPlayer,audioClip));
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
            Debug.LogError("No sound type found");
            return null;
        }

        //Delete audio after it is done playing to save memory
        IEnumerator DeleteAudioObject(GameObject audioObject,AudioClip audioClip) 
        {
            yield return new WaitForSeconds(audioClip.length);
            Destroy(audioObject);
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
    }
}
