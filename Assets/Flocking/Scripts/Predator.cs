using UnityEngine;
using System.Collections;

public class Predator : MonoBehaviour
{
    public Vector3 position;

    void Update()
    {
        position = transform.position;
    }
}

//public class Predator : Agent
//{
//    override protected Vector3 combineBehaviours()
//    {
//        return config.wanderCoeff * wanderBehaviour();
//    }
//}
