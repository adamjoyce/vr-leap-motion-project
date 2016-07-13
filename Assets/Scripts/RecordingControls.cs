using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Leap;

namespace Leap.Unity
{
    public class RecordingControls : MonoBehaviour
    {
        public bool enableRecording;
        public TextAsset RecordingAsset;
        public bool looping;
        Recorder recorder;

        LeapServiceProvider provider;
        Frame frame;

        public string header;
        public GUIText controlsGUI;
        public GUIText recordingGUI;

        public KeyCode beginRecordingKey = KeyCode.R;
        public KeyCode endRecordingKey = KeyCode.R;
        public KeyCode beginPlaybackKey = KeyCode.P;
        public KeyCode pausePlaybackKey = KeyCode.P;
        public KeyCode stopPlaybackKey = KeyCode.S;

        // Use this for initialization
        void Start()
        {
            frame = new Frame();
            recorder = new Recorder();
            provider = FindObjectOfType<LeapServiceProvider>();
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
                    EndRecording();
                    Debug.Log("Recording");
                    break;
                case RecorderState.Playing:
                    Pause();
                    Stop();
                    Debug.Log("Playing");
                    break;
                case RecorderState.Paused:
                    BeginPlayback();
                    Stop();
                    Debug.Log("Paused");
                    break;
                case RecorderState.Stopped:
                    BeginRecording();
                    BeginPlayback();
                    Debug.Log("Stopped");
                    break;
            }
        }

        //Begin recording
        private void BeginRecording()
        {
            if (controlsGUI != null)
                controlsGUI.text += beginRecordingKey + "-Begin Recording\n";
            
            if(Input.GetKeyDown(beginRecordingKey))
            {
                ResetRecording();
                Record();
                recordingGUI.text = "";
            }
        }


        //Star the playback fo the recording
        private void BeginPlayback()
        {
            if (controlsGUI != null)
                controlsGUI.text += beginPlaybackKey + "-Begin Playback\n";

            if(Input.GetKeyDown(beginPlaybackKey))
            {
                PlayRecording();
            }
        }

        //End the recording
        private void EndRecording()
        {
            if (controlsGUI != null)
                controlsGUI.text += endRecordingKey + "-End Recording\n";
            
            if(Input.GetKeyDown(endRecordingKey))
            {
                string savePath = "";
                recordingGUI.text = "Recording saved to: \n" + savePath;
            }
        }

        //Pause the playback
        private void Pause()
        {
            if (controlsGUI != null)
                controlsGUI.text += pausePlaybackKey + "-Paused Playback\n";

            if(Input.GetKeyDown(pausePlaybackKey))
            {
                PauseRecording();
            }
        }

        //Stop the playback
        private void Stop()
        {
            if (controlsGUI != null)
                controlsGUI.text += stopPlaybackKey + "-Stopped Playback\n";

            if(Input.GetKeyDown(stopPlaybackKey))
            {
                StopRecording();
            }
        }
    }
}