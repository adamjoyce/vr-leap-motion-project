using UnityEngine;
using System.Collections;

public class FlockingBehaviour : MonoBehaviour
{
    public float zoneWidth = 100.0f;
    public float zoneHeight = 100.0f;
    public float zoneDepth = 100.0f;

    public GameObject agentPrefab;
    public int agentNumber = 20;
    public GameObject[] agents;

    public float velocityScale = 10.0f;
    public float neighbourDistance = 100.0f;

    public float alignmentWeight = 1.0f;
    public float cohesionWeight = 1.0f;
    public float seperationWeight = 1.0f;


    // Use this for initialization.
    void Start()
    {
        if (!agentPrefab)
            agentPrefab = (GameObject)Resources.Load("/Prefabs/agent");

        agents = new GameObject[agentNumber];

        // Spawn agents randomly in the world.
        spawnAgents();
    }

    // Update is called once per frame.
    void Update()
    {
        for (int i = 0; i < agents.Length; i++)
        {
            Vector3 alignment = computeAlignment(agents[i]);
            Vector3 cohesion = computeCohesion(agents[i]);
            Vector3 seperation = computeSeperation(agents[i]);

            Vector3 velocity = agents[i].GetComponent<Rigidbody>().velocity;
            velocity += (alignment * alignmentWeight) + (cohesion * cohesionWeight) + (seperation * seperationWeight);
            velocity = velocity.normalized * 20.0f;

            agents[i].GetComponent<Rigidbody>().velocity = velocity;
        }
    }

    // Returns half the zone width.
    public float getZoneHalfWidth()
    {
        return zoneWidth * 0.5f;
    }

    // Returns half the zone height.
    public float getZoneHalfHeight()
    {
        return zoneHeight * 0.5f;
    }

    // Returns half the zone depth.
    public float getZoneHalfDepth()
    {
        return zoneDepth * 0.5f;
    }

    // Spawns all agents at random locations with random rotations.
    private void spawnAgents()
    {
        for (int i = 0; i < agentNumber; i++)
        {
            Vector3 pos = generateRandomLocation();
            GameObject agent = Instantiate(agentPrefab, pos, Quaternion.identity) as GameObject;
            agent.GetComponent<Agent>().velocity = generateVelocity();
            agents[i] = agent;
        }
    }

    // Calulate the alignment of the agent.
    private Vector3 computeAlignment(GameObject agent)
    {
        Vector3 newAlignement = new Vector3();
        int neighbourCount = 0;

        for (int i = 0; i < agents.Length; i++)
        {
            if (agents[i] != agent && Mathf.Abs(Vector3.Distance(agents[i].transform.position, agent.transform.position)) <= neighbourDistance)
            {
                newAlignement.x += agents[i].GetComponent<Rigidbody>().velocity.x;
                newAlignement.y += agents[i].GetComponent<Rigidbody>().velocity.y;
                newAlignement.z += agents[i].GetComponent<Rigidbody>().velocity.z;
                neighbourCount++;
            }
        }

        if (neighbourCount == 0)
            return newAlignement;

        newAlignement.x /= neighbourCount;
        newAlignement.y /= neighbourCount;
        newAlignement = newAlignement.normalized;
        return newAlignement;
    }

    // Calculate the cohesion of the agent (how much the agent steers towards a 'center of mass'.
    private Vector3 computeCohesion(GameObject agent)
    {
        Vector3 newDirection = new Vector3();
        int neighbourCount = 0;

        for (int i = 0; i < agents.Length; i++)
        {
            if (agents[i] != agent && Mathf.Abs(Vector3.Distance(agents[i].transform.position, agent.transform.position)) <= neighbourDistance)
            {
                newDirection.x += agents[i].transform.position.x;
                newDirection.y += agents[i].transform.position.y;
                newDirection.z += agents[i].transform.position.z;
                neighbourCount++;
            }
        }

        if (neighbourCount == 0)
            return newDirection;

        newDirection.x /= neighbourCount;
        newDirection.y /= neighbourCount;
        newDirection = new Vector3(newDirection.x - agent.transform.position.x, newDirection.y - agent.transform.position.y, newDirection.z - agent.transform.position.z);
        newDirection = newDirection.normalized;
        return newDirection;
    }

    //
    private Vector3 computeSeperation(GameObject agent)
    {
        Vector3 newDirection = new Vector3();
        int neighbourCount = 0;

        for (int i = 0; i < agents.Length; i++)
        {
            if (agents[i] != agent && Mathf.Abs(Vector3.Distance(agents[i].transform.position, agent.transform.position)) <= neighbourDistance)
            {
                newDirection.x += agents[i].transform.position.x - agent.transform.position.x;
                newDirection.y += agents[i].transform.position.y - agent.transform.position.y;
                newDirection.z += agents[i].transform.position.z - agent.transform.position.z;
                neighbourCount++;
            }
        }

        if (neighbourCount == 0)
            return newDirection;

        newDirection.x /= neighbourCount;
        newDirection.y /= neighbourCount;
        newDirection *= -1;
        newDirection *= -1;
        newDirection = newDirection.normalized;
        return newDirection;
    }

    //private void avoidWalls(GameObject agent)
    //{
    //    Vector3 newDirection = new Vector3();
    //    if (agent.transform.position.x < )
    //}

    // Returns a random position within the simulation zone.
    private Vector3 generateRandomLocation()
    {
        float halfZoneWidth = getZoneHalfWidth();
        float halfZoneHeight = getZoneHalfHeight();
        float halfZoneDepth = getZoneHalfDepth();

        float randX = Random.Range(-halfZoneWidth, halfZoneWidth);
        float randY = Random.Range(-halfZoneHeight, halfZoneHeight);
        float randZ = Random.Range(-halfZoneDepth, halfZoneDepth);

        return new Vector3(randX, randY, randZ);
    }

    // Returns a random velocity.
    private Vector3 generateVelocity()
    {
        return new Vector3(Random.value, Random.value, Random.value) * velocityScale;
    }

    //
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;

        // Draw simulation zone.
        // Close bottom left corner.
        Gizmos.DrawLine(new Vector3(-getZoneHalfWidth(), -getZoneHalfHeight(), -getZoneHalfDepth()), new Vector3(-getZoneHalfWidth(), getZoneHalfHeight(), -getZoneHalfDepth()));
        Gizmos.DrawLine(new Vector3(-getZoneHalfWidth(), -getZoneHalfHeight(), -getZoneHalfDepth()), new Vector3(-getZoneHalfWidth(), -getZoneHalfHeight(), getZoneHalfDepth()));
        Gizmos.DrawLine(new Vector3(-getZoneHalfWidth(), -getZoneHalfHeight(), -getZoneHalfDepth()), new Vector3(getZoneHalfWidth(), -getZoneHalfHeight(), -getZoneHalfDepth()));

        // Close bottom right corner.
        Gizmos.DrawLine(new Vector3(getZoneHalfWidth(), -getZoneHalfHeight(), -getZoneHalfDepth()), new Vector3(getZoneHalfWidth(), getZoneHalfHeight(), -getZoneHalfDepth()));
        Gizmos.DrawLine(new Vector3(getZoneHalfWidth(), -getZoneHalfHeight(), -getZoneHalfDepth()), new Vector3(getZoneHalfWidth(), -getZoneHalfHeight(), getZoneHalfDepth()));

        // Close top left corner.
        Gizmos.DrawLine(new Vector3(-getZoneHalfWidth(), getZoneHalfHeight(), -getZoneHalfDepth()), new Vector3(-getZoneHalfWidth(), getZoneHalfHeight(), getZoneHalfDepth()));
        Gizmos.DrawLine(new Vector3(-getZoneHalfWidth(), getZoneHalfHeight(), -getZoneHalfDepth()), new Vector3(getZoneHalfWidth(), getZoneHalfHeight(), -getZoneHalfDepth()));

        // Close top right corner.
        Gizmos.DrawLine(new Vector3(getZoneHalfWidth(), getZoneHalfHeight(), -getZoneHalfDepth()), new Vector3(getZoneHalfWidth(), getZoneHalfHeight(), getZoneHalfDepth()));

        // Far bottom left corner.
        Gizmos.DrawLine(new Vector3(-getZoneHalfWidth(), -getZoneHalfHeight(), getZoneHalfDepth()), new Vector3(-getZoneHalfWidth(), getZoneHalfHeight(), getZoneHalfDepth()));
        Gizmos.DrawLine(new Vector3(-getZoneHalfWidth(), -getZoneHalfHeight(), getZoneHalfDepth()), new Vector3(getZoneHalfWidth(), -getZoneHalfHeight(), getZoneHalfDepth()));

        // Far bottom right corner.
        Gizmos.DrawLine(new Vector3(getZoneHalfWidth(), -getZoneHalfHeight(), getZoneHalfDepth()), new Vector3(getZoneHalfWidth(), getZoneHalfHeight(), getZoneHalfDepth()));

        // Far top left corner.
        Gizmos.DrawLine(new Vector3(-getZoneHalfWidth(), getZoneHalfHeight(), getZoneHalfDepth()), new Vector3(getZoneHalfWidth(), getZoneHalfHeight(), getZoneHalfDepth()));
    }
}