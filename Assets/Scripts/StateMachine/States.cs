using UnityEngine;
using System.Collections;


public class StartState : State<GameManager>
{
    public void execute(GameManager gm, StateMachine<GameManager> fsm)
    {
        // Commented out as title screen / menu isn't implemented.
        Debug.Log("Executing Start State");
        //if (Input.GetMouseButtonDown(0))
            fsm.SetState(new GestureTutorialState());
    }

    public void enter(GameManager gm)
    {
        Debug.Log("Entered Start State");
    }

    public void exit(GameManager gm)
    {
        Debug.Log("Exited Start State");
    }
}

public class GestureTutorialState : State<GameManager>
{
    public void execute(GameManager gm, StateMachine<GameManager> fsm)
    {
        //Debug.Log("Executing GestureTutorial State");
        //if (Input.GetMouseButtonDown(0))
            fsm.SetState(new GameStartState());
    }

    public void enter(GameManager gm)
    {
        //Debug.Log("Entered GestureTutorial State");
    }

    public void exit(GameManager gm)
    {
        //Debug.Log("Exited GestureTutorial State");
    }
}

public class GameStartState : State<GameManager>
{
    public void execute(GameManager gm, StateMachine<GameManager> fsm)
    {
        //Debug.Log("Executing GameStartState State");
        if (Input.GetMouseButtonDown(0)) { }
        //fsm.SetState(new );
    }

    public void enter(GameManager gm)
    {
        //Debug.Log("Entered GameStartState State");
    }

    public void exit(GameManager gm)
    {
        //Debug.Log("Exited GameStartState State");
    }
}
