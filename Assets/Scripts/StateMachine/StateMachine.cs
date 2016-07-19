public class StateMachine<A>
{
    A agent;
    State<A> current;

    public StateMachine(A a)
    {
        agent = a;
    }

    public A GetAgent()
    {
        return agent;
    }

    public State<A> GetState()
    {
        return current;
    }

    public void SetState(State<A> next)
    {
        if (current != null)
        {
            current.exit(agent);
        }
        current = next;
        current.enter(agent);
    }

    public void Update()
    {
        current.execute(agent, this);
    }
}