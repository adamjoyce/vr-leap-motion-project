using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Leap;

namespace Leap.Unity
{
    //States
    public enum RecorderState
    {
        Recording = 0,
        Playing = 1,
        Paused = 2,
        Stopped = 3,
    }

    //Recorder class
    public class Recorder
    {
        public float playbackSpeed = 1.0f;
        public bool isLooping = true;

        public RecorderState state = RecorderState.Playing;

        protected List<byte[]> frames;
        protected float frameIndex;
        protected Frame currentFrame = new Frame();

        //New recorder, reset variables
        public void Recorder()
        {
            Reset();
        }

        //Set the state to Stopped
        public void Stop()
        {
            state = RecorderState.Stopped;
            frameIndex = 0.0f;
        }

        //Set the state to Paused
        public void Pause()
        {
            state = RecorderState.Paused;
        }

        //Set the state to Playing
        public void Play()
        {
            state = RecorderState.Playing;
        }

        //Set the state to Recording
        public void Record()
        {
            state = RecorderState.Recording;
        }

        //Reset variables
        public void Reset()
        {
            frames = new List<byte[]>();
            frameIndex = 0.0f;
        }

        //Get the progress
        public float GetProgress()
        {
            return frameIndex / frames.Count;
        }

        //Get the index
        public int GetIndex()
        {
            return (int)frameIndex;
        }
    }
}