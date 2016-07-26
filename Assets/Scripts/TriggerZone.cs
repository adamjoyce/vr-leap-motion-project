using UnityEngine;
using System.Collections.Generic;

public class TriggerZone : MonoBehaviour
{
    public List<Collider> collidersInTriggerZone;

    // Use this for initialization
    void Start()
    {
        collidersInTriggerZone = new List<Collider>();
    }

    //
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "BubbleSphere" && GetComponentInParent<Collider>() != other && !collidersInTriggerZone.Contains(other))
            collidersInTriggerZone.Add(other);
    }

    //
    private void OnTriggerExit(Collider other)
    {
        if (collidersInTriggerZone.Contains(other))
            collidersInTriggerZone.Remove(other);
    }
}