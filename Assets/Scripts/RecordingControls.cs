using UnityEngine;
using System.Collections;
using Leap;

namespace Leap.Unity
{
    public class RecordingControls : MonoBehaviour
    {
        public bool enableRecording;
        public TextAsset eecordingAsset;
        public bool looping;
        Recorder recorder;

        LeapProvider provider;

        public string header;
        public GUIText controlsGUI;
        public GUIText recordingGUI;

        public KeyCode beginRecordingKey = KeyCode.R;
        public KeyCode endRecordingKey = KeyCode.R;
        public KeyCode beginPlaybackKey = KeyCode.P;
        public KeyCode endPlaybackKey = KeyCode.P;
        public KeyCode stopPlaybackKey = KeyCode.S;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}