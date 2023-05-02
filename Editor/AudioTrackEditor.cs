using UnityEditor;
using UnityEngine;

namespace RadiantGames.AudioSystem
{
    [CustomEditor(typeof(AudioTrackManager))]
    public class AudioTrackEditor : Editor
    {
        string userTrackName = "";
        public override void OnInspectorGUI()
        {
            //base.OnInspectorGUI();
            userTrackName = EditorGUILayout.TextField("Track Name", userTrackName);
            if (GUILayout.Button("Add Track"))
            {
                AudioTrackManager.AddAudioTrack(userTrackName);
                UpdateTrackList();
            }
            if (GUILayout.Button("Remove Track"))
            {
                AudioTrackManager.RemoveAudioTrack(userTrackName);
                UpdateTrackList();
            }
            UpdateTrackList();
        }

        /// <summary>
        /// Refreshes the Track List UI when called
        /// </summary>
        public void UpdateTrackList()
        {
            foreach (AudioTrack audiotrack in AudioTrackManager.AllAudioTracks)
            {
                MakeTrackUI(audiotrack);
            }
        }

        /// <summary>
        /// Make User Interface in Inspector for a given Track
        /// </summary>
        /// <param name="audioTrack">Track for which to generate UI</param>
        public void MakeTrackUI(AudioTrack audioTrack)
        {
            GUILayout.BeginVertical("HelpBox");

            GUILayout.Label(audioTrack.trackName);

            GUILayout.BeginHorizontal();

            GUILayout.BeginVertical("GroupBox");

            GUILayout.BeginHorizontal();
            GUILayout.Label("Audio Clip");
            EditorGUILayout.ObjectField(audioTrack.clip, typeof(AudioClip), true);
            GUILayout.EndHorizontal();

            audioTrack.volume = EditorGUILayout.IntSlider(audioTrack.volume, 0, 100);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Play at start");
            audioTrack.playAtStart = EditorGUILayout.Toggle(audioTrack.playAtStart);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Loop");
            audioTrack.loop = EditorGUILayout.Toggle(audioTrack.loop);
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();

            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
        }
    }
}
