using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RadiantGames.Tools.AudioSystem
{
    public class MusicHandler : MonoBehaviour
    {
        public static AudioSource musicSource;
        public AudioClip[] musicList;

        void Start()
        {
            musicSource = GetComponent<AudioSource>();
            StartCoroutine(PlayMusic());
        }

        IEnumerator PlayMusic()
        {
            if (musicList == null) { yield return null; }

            //Looping throught the musicList
            int k = 0;
            while (k < musicList.Length)
            {
                musicSource.clip = musicList[k];
                musicSource.Play();
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

    }
}
