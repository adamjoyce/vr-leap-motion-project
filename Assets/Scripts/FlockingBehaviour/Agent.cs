using UnityEngine;
using System.Collections;

public class Agent : MonoBehaviour
{
    public Vector3 velocity;

    private Rigidbody rb;
    private GameObject flockingController;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        flockingController = GameObject.Find("FlockingController");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 collisionNormal = zoneCollision();
        if (collisionNormal != Vector3.zero)
            rb.velocity = Vector3.Reflect(rb.velocity, collisionNormal);
        else
            rb.velocity = velocity;

    }

    // Returns the normal of the side the agent is colliding with or a zero vector for no collision.
    private Vector3 zoneCollision()
    {
        Vector3 zoneSide = Vector3.zero;
        Vector3 pos = GetComponent<Transform>().position;

        // Left and Right.
        if (pos.x <= -flockingController.GetComponent<FlockingBehaviour>().getZoneHalfWidth())
            zoneSide = Vector3.right;
        else if (pos.x >= flockingController.GetComponent<FlockingBehaviour>().getZoneHalfWidth())
            zoneSide = Vector3.left;

        // Top and Down.
        if (pos.y <= -flockingController.GetComponent<FlockingBehaviour>().getZoneHalfHeight())
            zoneSide = Vector3.up;
        else if (pos.y >= flockingController.GetComponent<FlockingBehaviour>().getZoneHalfHeight())
            zoneSide = Vector3.down;

        // Front and Back.
        if (pos.z <= -flockingController.GetComponent<FlockingBehaviour>().getZoneHalfDepth())
            zoneSide = Vector3.forward;
        else if (pos.z >= flockingController.GetComponent<FlockingBehaviour>().getZoneHalfDepth())
            zoneSide = Vector3.back;

        return zoneSide;
    }
}