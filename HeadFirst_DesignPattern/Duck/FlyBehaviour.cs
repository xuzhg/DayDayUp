namespace DuckConsole;

public class FlyWithWings : IFlyBehaviour
{
    public virtual void fly()
    {
        System.Console.WriteLine("I am flying with wings.");
    }
}

public class FlyNoWay : IFlyBehaviour
{
    public virtual void fly()
    {
        System.Console.WriteLine("I can't fly.");
    }
}


public class FlyRocketPowered : IFlyBehaviour
{
    public void fly()
    {
        System.Console.WriteLine("I'm flying with a rocket.");
    }
}