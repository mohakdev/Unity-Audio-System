using System;
using UnityEngine;

namespace RadiantTools.AudioSystem
{
    [Serializable]
    public class SoundClips
    {
        public SoundTypes soundType;
        public AudioClip audioClip;
    }
    public enum SoundTypes
    {
        AudioOne,
        AudioTwo
    }
}
