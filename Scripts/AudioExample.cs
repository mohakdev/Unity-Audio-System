using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantTools.AudioSystem
{
    public class AudioExample : MonoBehaviour
    {
        void Start()
        {
            Invoke(nameof(ExampleAudio), 3f);
            Invoke(nameof(ExampleAudioTwo), 6f);
        }

        void ExampleAudio()
        {
            //Simply playing a sound
            AudioManager.Instance.PlayAudio(AudioManager.SoundTypes.AudioTwo);
        }
        void ExampleAudioTwo()
        {
            //Changing settings of audio as well
            AudioSettings audioSettings = new()
            {
                pitch = 1.3f,
                volume = 0.6f
            };
            AudioManager.Instance.PlayAudio(AudioManager.SoundTypes.AudioOne, audioSettings);
        }
    }
}
