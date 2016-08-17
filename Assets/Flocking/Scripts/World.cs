using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour
{
    public Transform agentPrefab;
    public int numberOfAgents;
    public float bound;
    public float spawnRadius;

    private List<Agent> agents;
    public List<Predator> predators;

    // Use this for initialization.
    void Start()
    {
        agents = new List<Agent>();
        predators = new List<Predator>();

        spawnAgents(agentPrefab, numberOfAgents);
        agents.AddRange(FindObjectsOfType<Agent>());
        predators.AddRange(FindObjectsOfType<Predator>());
    }

    // Update is called once per frame.
    void Update()
    {

    }

    //
    public void addPredator(GameObject predator)
    {
        predators.Add(predator.GetComponent<Predator>());
    }

    // Returns the neighbours of agent inside radius.
    public List<Agent> getNeighbours(Agent agent, float radius)
    {
        List<Agent> neighbourAgents = new List<Agent>();
        for (int i = 0; i < agents.Count; i++)
        {
            if (agents[i] != agent && Vector3.Distance(agent.position, agents[i].position) <= radius)
                neighbourAgents.Add(agents[i]);
        }

        return neighbourAgents;
    }

    // Returns the preadtors inside the radius.
    public List<Predator> getPredators(Agent agent, float radius)
    {
        List<Predator> predatorAgents = new List<Predator>();
        for (int i = 0; i < predators.Count; i++)
        {
            if (Vector3.Distance(agent.position, predators[i].position) <= radius)
                predatorAgents.Add(predators[i]);
        }

        return predatorAgents;
    }

    // Randomly spawns a number of agents in the scene.
    private void spawnAgents(Transform prefab, int agentNumber)
    {
        for (int i = 0; i < agentNumber; i++)
        {
            GameObject agent = Instantiate(prefab, new Vector3(Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius), Random.Range(-spawnRadius, spawnRadius)), Quaternion.identity) as GameObject;
        }
    }
}
