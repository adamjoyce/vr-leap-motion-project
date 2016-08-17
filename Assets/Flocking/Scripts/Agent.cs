using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Agent : MonoBehaviour
{
    public Vector3 position;
    public Vector3 velocity;
    public Vector3 acceleration;
    public World world;
    public AgentConfig config;

    private Vector3 wanderTarget;

    // Use this for initialization.
    protected void Start()
    {
        world = FindObjectOfType<World>();
        config = FindObjectOfType<AgentConfig>();
        position = transform.position;
        velocity = new Vector3(Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f), Random.Range(-3.0f, 3.0f));
    }

    // Update is called once per frame.
    void Update()
    {
        float time = Time.deltaTime;

        acceleration = combineBehaviours();
        acceleration = Vector3.ClampMagnitude(acceleration, config.maxAcceleration);

        velocity += acceleration * time;
        velocity = Vector3.ClampMagnitude(velocity, config.maxVelocity);

        position += velocity * time;

        wrapAround(ref position, -world.bound, world.bound);
        transform.position = position;

        if (velocity.magnitude > 0)
            transform.LookAt(position + velocity);
    }

    // Steers the agent's current velocity towards the centre of mass of all nearby neighbours.
    private Vector3 cohesionBehaviour()
    {
        Vector3 resultantVector = new Vector3();
        int agentsCount = 0;

        // Get all nearby neighbours.
        List<Agent> neighbours = world.getNeighbours(this, config.cohesionRadius);

        // Zero neighbours results in no cohesion desire.
        if (neighbours.Count == 0)
            return resultantVector;

        // Find the centre of mass of all neighbours.
        for (int i = 0; i < neighbours.Count; i++)
        {
            if (inFieldOfVision(neighbours[i].position))
            {
                resultantVector += neighbours[i].position;
                agentsCount++;
            }
        }

        // No neighbours in field of view.
        if (agentsCount == 0)
            return resultantVector;

        resultantVector /= agentsCount;

        // Vector towards centre of mass and normalise.
        resultantVector = resultantVector - position;

        return resultantVector.normalized;
    }

    // Steers the agent in the opposite direction from each of its neighbours.
    private Vector3 seperationBehaviour()
    {
        Vector3 resultantVector = new Vector3();

        // Get all nearby neighbours.
        List<Agent> neighbours = world.getNeighbours(this, config.seperationRadius);

        // Zero neighbours results in no seperation desire.
        if (neighbours.Count == 0)
            return resultantVector;

        // Add the contribution from each neighbour towards this agent.
        for (int i = 0; i < neighbours.Count; i++)
        {
            if (inFieldOfVision(neighbours[i].position))
            {
                Vector3 towardsAgent = position - neighbours[i].position;

                // The force contribution will vary inversely to the distance.
                if (towardsAgent.magnitude > 0)
                    resultantVector += towardsAgent.normalized / towardsAgent.magnitude;
            }
        }

        return resultantVector.normalized;
    }

    // Steers the agent to match the velocity of its neighbours.
    private Vector3 alignmentBehaviour()
    {
        Vector3 resultantVector = new Vector3();

        // Get all nearby neighbours.
        List<Agent> neighbours = world.getNeighbours(this, config.alignmentRadius);

        // Zero neighbours results in no alignement desire.
        if (neighbours.Count == 0)
            return resultantVector;

        // Match veloicty of all nearby neighbours.
        for (int i = 0; i < neighbours.Count; i++)
            if (inFieldOfVision(neighbours[i].position))
                resultantVector += neighbours[i].velocity;

        return resultantVector.normalized;
    }

    // Combines all behaviours according to their wieghtings.
    protected virtual Vector3 combineBehaviours()
    {
        Vector3 resultantAccelreation = new Vector3();

        // Cohesion, seperation, and alignement normalised desire vectors.
        Vector3 cohesionDesire = cohesionBehaviour();
        Vector3 seperationbDesire = seperationBehaviour();
        Vector3 alignmentDesire = alignmentBehaviour();

        // Combine all desire vectors with their associated weightings.
        resultantAccelreation = config.cohesionCoeff * cohesionDesire + config.seperationCoeff * seperationbDesire + config.alignmentCoeff * alignmentDesire + 
                                config.wanderCoeff * wanderBehaviour() + config.avoidCoeff * avoidPredators();

        return resultantAccelreation;
    }

    // Wraps around the given position to keep it within the min - max range.
    private void wrapAround(ref Vector3 position, float min, float max)
    {
        position.x = wrapAroundFloat(position.x, min, max);
        position.y = wrapAroundFloat(position.y, min, max);
        position.z = wrapAroundFloat(position.z, min, max);
    }

    // Bounds value within the min - max range.
    private float wrapAroundFloat(float value, float min, float max)
    {
        if (value > max)
            value = min;
        else if (value < min)
            value = max;
        return value;
    }

    // Determines if a given neighbour is within the agent's field of vision.
    private bool inFieldOfVision(Vector3 neighbourPosition)
    {
        return Vector3.Angle(velocity, neighbourPosition - position) <= config.maxFieldOfViewAngle;
    }

    // Steers the agent towards a random wander target location.
    protected Vector3 wanderBehaviour()
    {
        float jitter = config.wanderJitter * Time.deltaTime;

        // Random direction vector deviation for target position.
        wanderTarget += new Vector3(randomBinomial() * jitter, 0, randomBinomial() * jitter);

        // Project the vector back to the unit 'wander' circle.
        wanderTarget = wanderTarget.normalized;

        // Makes the length the same as the wander circle's radius.
        wanderTarget *= config.wanderRadius;

        // Position the target circle in front of agent.
        Vector3 targetInLocalSpace = wanderTarget + new Vector3(0, 0, config.wanderDistance);

        // Project the target circle from local space to world space.
        Vector3 targetInWorldSpace = transform.TransformPoint(targetInLocalSpace);

        // Steer agent towards target on circle.
        targetInWorldSpace -= position;

        return targetInWorldSpace.normalized;
    }

    // Generates a random number between -1.0f and 1.0f with a greater chance of the result being closer to 0.0f that the extremities.
    private float randomBinomial()
    {
        return Random.Range(0.0f, 1.0f) - Random.Range(0.0f, 1.0f);
    }

    // Makes the agent flee from nearby enemies.
    private Vector3 avoidPredators()
    {
        Vector3 resultantVector = new Vector3();

        // Get all enemies.
        List<Predator> predators = world.getPredators(this, config.avoidRadius);

        // Zero predators means no need to flee.
        if (predators.Count == 0)
            return resultantVector;

        // Flee from the predators.
        for (int i = 0; i < predators.Count; i++)
        {
            //Vector3 fleeVector = flee(predators[i].position) * Quaternion.AngleAxis(-90, Vector3.left);
            resultantVector += flee(predators[i].position);
        }

        return resultantVector.normalized;
    }

    // Run in the opposite direction of the target.
    private Vector3 flee(Vector3 targetPosition)
    {
        Vector3 desiredVelocity = (position - targetPosition).normalized * config.maxVelocity;
        return desiredVelocity - velocity;
    }
}
