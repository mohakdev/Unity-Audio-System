using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.AudioSystem
{
    public class AudioTrackManager : MonoBehaviour
    {

        //TODO: Save this field using Scriptable Objects 
        public static List<AudioTrack> AllAudioTracks = new();

        /// <summary>
        /// Adds a audio track 
        /// </summary>
        /// <param name="trackName">name of the audio track</param>
        /// <returns>desired audio track with custom name and default settings</returns>
        public static AudioTrack AddAudioTrack(string trackName)
        {
            AudioTrack audioTrack = new(trackName);
            AllAudioTracks.Add(audioTrack);
            return audioTrack;
        }
        /// <summary>
        /// Finds a given audio track
        /// </summary>
        /// <param name="name">name of the audio track you want to find</param>
        /// <returns></returns>
        public static AudioTrack FindAudioTrack(string name)
        {
            foreach (AudioTrack track in AllAudioTracks)
            {
                if (track.trackName.Equals(name))
                {
                    return track;
                }
            }
            return null;
        }
        public static void RemoveAudioTrack(string trackName)
        {
            foreach(AudioTrack track in AllAudioTracks)
            {
                if (track.trackName.Equals(trackName))
                {
                    AllAudioTracks.Remove(track);
                    break;
                }
            }
        }
    }

    public class AudioTrack
    {
        public string trackName;
        public AudioClip clip;
        public int volume;
        public bool playAtStart;
        public bool loop;

        public AudioTrack(string trackName)
        {
            this.trackName = trackName;
            volume = 0;
            playAtStart = false;
            loop = false;
        }
    }
}
