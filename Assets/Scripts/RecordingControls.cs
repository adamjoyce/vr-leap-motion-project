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
            recorder = new Recorder();
            provider = FindObjectOfType<LeapProvider>();
        }

        //Get the recorder
        public Recorder GetRecorder()
        {
            return recorder;
        }

        //Clears the last recording
        public void ResetRecording()
        {
            recorder.Reset();
        }

        //Call to record
        public void Record()
        {
            recorder.Record();
        }

        //Call to play recording
        public void PlayRecording()
        {
            recorder.Play();
        }

        //Call to pause recording
        public void PauseRecording()
        {
            recorder.Pause();
        }

        //Call to stop recording
        public void StopRecording()
        {
            recorder.Stop();
        }

        void Update()
        {
            if (controlsGUI != null)
                controlsGUI.text = header + "\n";

            switch(GetRecorder().state)
            {
                case RecorderState.Recording:
                    Debug.Log("Recording");
                    break;
                case RecorderState.Playing:
                    Debug.Log("Playing");
                    break;
                case RecorderState.Paused:
                    Debug.Log("Paused");
                    break;
                case RecorderState.Stopped:
                    Debug.Log("Stopped");
                    break;
            }
        }
    }
}