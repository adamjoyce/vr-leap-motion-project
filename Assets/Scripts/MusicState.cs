using UnityEngine;
using System.Collections;

public class MusicState : MonoBehaviour {

    public GameObject currentMusicProptery;

	// Use this for initialization
	void Start () {
        currentMusicProptery = null;
    }
    
    //
    public void SetCurrentMusicProperty(GameObject musicProperty) {
        currentMusicProptery = musicProperty;
    }

    //
    public GameObject GetCurrentMusicProperty() {
        return currentMusicProptery;
    }
}
