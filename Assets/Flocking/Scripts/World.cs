using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class World : MonoBehaviour
{
    public Transform agentPrefab;
    public int numberOfAgents;
    public float bound;
    public int numberOfSubdivision;
    public float spawnRadius;

    public bool threeDimensions = false;

    public List<Agent>[,] bins;
    private List<Agent> agents;
    private List<Predator> predators;

    // Use this for initialization.
    void Start()
    {
        // Build bins.
        buildWorldBins();

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

    // Returns the neighbours of agent inside radius.
    public List<Agent> getNeighbours(Agent agent, float radius)
    {
        List<Agent> neighbourAgents = new List<Agent>();
        List<Agent> neighbours = new List<Agent>(bins[(int)agent.binLocation.x, (int)agent.binLocation.z]);
        for (int i = 0; i < neighbours.Count; i++)
        {
            if (neighbours[i] != agent && Vector3.Distance(agent.position, neighbours[i].position) <= radius)
                neighbourAgents.Add(neighbours[i]);
        }


            //List<Vector3> neighbourBins = getAdjacentBins(agent.binLocation);

            //for (int i = 0; i < neighbourBins.Count; i++)
            //{
            //    List<Agent> neighbours = new List<Agent>(bins[(int)neighbourBins[i].x, (int)neighbourBins[i].z]);
            //    for (int j = 0; j < neighbours.Count; j++)
            //    {
            //        neighbourAgents.Add(neighbours[j]);
            //    }
            //}

            //for (int i = 0; i < agents.Count; i++)
            //{
            //    if (agents[i] != agent && Vector3.Distance(agent.position, agents[i].position) <= radius)
            //        neighbourAgents.Add(agents[i]);
            //}

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

    //
    public List<Vector3> getAdjacentBins(Vector3 centralBin)
    {
        List<Vector3> resultantBins = new List<Vector3>();
        //for (int dx = -1; dx <= 1; dx++)
        //{
        //    for (int dz = -1; dz <= 1; dz++)
        //    {
        //        int x = (int)centralBin.x + dx;
        //        int z = (int)centralBin.z + dz;

        //        // Wrap around.
        //        if (x == numberOfSubdivision)
        //            x = 0;
        //        else if (x < 0)
        //            x = numberOfSubdivision - 1;

        //        //if (y == numberOfSubdivision)
        //        //    y = 0;
        //        //else if (y < 0)
        //        //    y = numberOfSubdivision - 1;

        //        if (z == numberOfSubdivision)
        //            z = 0;
        //        else if (z < 0)
        //            z = numberOfSubdivision - 1;

        //        resultantBins.Add(new Vector3(x, 0, z));
        //    }
        //}

        resultantBins.Add(centralBin);
        return resultantBins;
    }

    // Returns the bin location for the agent given.
    public Vector3 determineAgentBin(Agent agent)
    {
        float binSize = (bound * 2) / numberOfSubdivision;
        int binX = (int)Mathf.Floor(agent.position.x / binSize);
        int binZ = (int)Mathf.Floor(agent.position.z / binSize);

        int binY;
        if (threeDimensions)
            binY = (int)Mathf.Floor(agent.position.y / binSize);
        else
            binY = 0;

        // Wrap around.
        if (binX == numberOfSubdivision)
            binX = 0;
        else if (binX < 0)
            binX = numberOfSubdivision - 1;

        if (binY == numberOfSubdivision)
            binY = 0;
        else if (binY < 0)
            binY = numberOfSubdivision - 1;

        if (binZ == numberOfSubdivision)
            binZ = 0;
        else if (binZ < 0)
            binZ = numberOfSubdivision - 1;

        return new Vector3(binX, binY, binZ);
    }

    // Adds the given agent to the given bin.
    public void addAgentToBin(Agent agent, Vector3 bin)
    {
        bins[(int)bin.x, (int)bin.z].Add(agent);
    }

    // Removes the given agent from the given bin.
    public void removeAgentFromBin(Agent agent, Vector3 bin)
    {
        bins[(int)bin.x, (int)bin.z].Remove(agent);
    }
    
    // Sets up the world bins.
    private void buildWorldBins()
    {
        bins = new List<Agent>[numberOfSubdivision, numberOfSubdivision];
        for (int i = 0; i < numberOfSubdivision; i++)
        {
            for (int j = 0; j < numberOfSubdivision; j++)
            {
                bins[i, j] = new List<Agent>();
            }
        }
    }

    // Randomly spawns a number of agents in the scene.
    private void spawnAgents(Transform prefab, int agentNumber)
    {
        for (int i = 0; i < agentNumber; i++)
        {
            if (threeDimensions)
            {
                GameObject agent = Instantiate(prefab, new Vector3(Random.Range(-spawnRadius + bound, spawnRadius + bound), Random.Range(-spawnRadius + bound, spawnRadius + bound), Random.Range(-spawnRadius + bound, spawnRadius + bound)), Quaternion.identity) as GameObject;
            } 
            else
            {
                GameObject agent = Instantiate(prefab, new Vector3(Random.Range(-spawnRadius + bound, spawnRadius + bound), 0, Random.Range(-spawnRadius + bound, spawnRadius + bound)), Quaternion.identity) as GameObject;
            }
        }
    }
}
