using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.AudioSystem
{
    public class AudioManager : MonoBehaviour
    {
        void Start()
        {
            foreach(AudioTrack track in AudioTrackManager.AllAudioTracks)
            {
                GameObject audioObject = Instantiate(new GameObject(), transform);
                audioObject.name = track.trackName + " Source";
                AudioSource audioSource = audioObject.AddComponent<AudioSource>();

                audioSource.volume = track.volume;
                audioSource.clip = track.clip;
                audioSource.loop = track.loop;
                audioSource.playOnAwake = track.playAtStart;
            }
        }
        /// <summary>
        /// Plays your desired audioclip in your desired audiotrack
        /// </summary>
        /// <param name="track">Track you want to play this audio</param>
        /// <param name="clip">Audioclip you want to play</param>
        public static void PlaySound(AudioTrack track,AudioClip clip)
        {

        }
    }
}
