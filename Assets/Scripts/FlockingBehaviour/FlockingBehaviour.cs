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

    }

    // Spawns all agents at random locations with random rotations.
    private void spawnAgents()
    {
        for (int i = 0; i < agentNumber; i++)
        {
            Vector3 pos = generateRandomLocation();
            GameObject agent = Instantiate(agentPrefab, pos, Random.rotation) as GameObject;
            agents[i] = agent;
        }
    }

    // Returns a random position within the simulation zone.
    private Vector3 generateRandomLocation()
    {
        float halfZoneWidth = zoneWidth * 0.5f;
        float halfZoneHeight = zoneHeight * 0.5f;
        float halfZoneDepth = zoneDepth * 0.5f;

        float randX = Random.Range(-halfZoneWidth, halfZoneWidth);
        float randY = Random.Range(-halfZoneHeight, halfZoneHeight);
        float randZ = Random.Range(-halfZoneDepth, halfZoneDepth);

        return new Vector3(randX, randY, randZ);
    }
}