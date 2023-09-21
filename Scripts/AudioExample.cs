using System.Collections;
using UnityEngine;

namespace RadiantTools.AudioSystem
{
    public class AudioExample : MonoBehaviour
    {
        void Start()
        {
            AudioManager.Instance.DeleteAudioPlayer("Test");
            AudioPlayer customPlayer = AudioManager.Instance.MakeAudioPlayer("Test");
            customPlayer.SetAudioClip(customPlayer.GetAudioClip(SoundTypes.AudioTwo));
            customPlayer.SetAudioSettings(loop: true);
            customPlayer.PlayAudio();
        }

        IEnumerator PlaySampleAudio()
        {
            yield return new WaitForSeconds(4f);

            //To Play a Sound Effect
            AudioPlayer soundSFX = AudioManager.Instance.GetAudioPlayer("SoundSFX");
            soundSFX.PlayAudioOnce(SoundTypes.AudioOne);
            yield return new WaitForSeconds(4f);

            //To Make a Custom Audio Player
            AudioPlayer customPlayer = AudioManager.Instance.MakeAudioPlayer("ABCD");
            customPlayer.PlayAudioOnce(SoundTypes.AudioTwo);
        }
    }
}
