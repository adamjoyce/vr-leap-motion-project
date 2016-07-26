using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private static GameManager _instance;

    public StateMachine<GameManager> fsm;

    public static GameManager Instance
    {
        get
        {
            // Create logic to create the instance.
            if (_instance == null)
            {
                GameObject go = new GameObject("GameManager");
                go.AddComponent<GameManager>();
            }
            return _instance;
        }
    }

    void Start()
    {
        // Setup state machine.
        fsm = new StateMachine<GameManager>(this);
        fsm.SetState(new StartState());
    }

    public void Update()
    {
        fsm.Update();
    }

    public string GetLevel()
    {
        return SceneManager.GetActiveScene().name;
    }

    public void SetLevel(string levelName)
    {
        SceneManager.LoadScene("_Scenes/GameScenes/" + levelName);
    }

    void Awake()
    {
        _instance = this;
        //DontDestroyOnLoad(_instance);
    }

    // Sets the instance to null when the application quits.
    public void OnApplicationQuit()
    {
        _instance = null;
    }
}