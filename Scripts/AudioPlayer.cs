using UnityEngine;

namespace RadiantTools.AudioSystem
{
    public class AudioPlayer : MonoBehaviour
    {
        AudioSource audioSource;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayAudio(SoundTypes soundType)
        {
            //If audioSource is null then assign one
            if(audioSource == null) {
                audioSource = GetComponent<AudioSource>(); 
            }
            //Play the audio
            audioSource.PlayOneShot(GetAudioClip(soundType));
        }

        public void SetAudioPlayerSettings(float volume = 1f, float pitch = 1f, bool loop = false, bool playOnStart = false)
        {
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.loop = loop;
            audioSource.playOnAwake = playOnStart;
        }
        public AudioClip GetAudioClip(SoundTypes soundType)
        {
            foreach (SoundClips soundClip in AudioManager.Instance.audioList)
            {
                if (soundClip.soundType.Equals(soundType))
                {
                    return soundClip.audioClip;
                }
            }
            Debug.Log("ERROR -> No sound type found");
            return null;
        }
    }
}
