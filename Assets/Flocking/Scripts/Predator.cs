﻿using UnityEngine;
using System.Collections;

public class Predator : Agent
{
    //override protected Vector3 combineBehaviours()
    //{
    //    //return config.wanderCoeff * wanderBehaviour();
    //    return Vector3.zero;
    //}

    void Update()
    {
        velocity = Vector3.zero;
        position = transform.position;
    }
}
