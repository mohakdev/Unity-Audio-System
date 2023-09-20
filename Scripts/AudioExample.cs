using System.Collections;
using UnityEngine;

namespace RadiantTools.AudioSystem
{
    public class AudioExample : MonoBehaviour
    {
        void Start()
        {
            StartCoroutine(PlaySampleAudio());
        }

        IEnumerator PlaySampleAudio()
        {
            yield return new WaitForSeconds(4f);
            
            //To Play a Sound Effect
            AudioManager.Instance.GetAudioPlayer("SoundSFX").PlayAudio(SoundTypes.AudioTwo);
            yield return new WaitForSeconds(4f);

            //To Make a Custom Audio Player
            AudioPlayer customPlayer = AudioManager.Instance.MakeAudioPlayer("ABCD");
            customPlayer.PlayAudio(SoundTypes.AudioTwo);
        }
    }
}
