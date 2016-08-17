using UnityEngine;
using System.Collections;

public class AgentConfig : MonoBehaviour
{
    public float cohesionRadius = 30.0f;
    public float seperationRadius = 30.0f;
    public float alignmentRadius = 30.0f;
    public float avoidRadius = 30.0f;

    public float cohesionCoeff = 100.0f;
    public float seperationCoeff = 100.0f;
    public float alignmentCoeff = 100.0f;
    public float wanderCoeff = 100.0f;
    public float avoidCoeff = 100.0f;

    public float maxAcceleration = 10.0f;
    public float maxVelocity = 10.0f;

    public float maxFieldOfViewAngle = 180.0f;

    public float wanderRadius;
    public float wanderJitter;
    public float wanderDistance;
}