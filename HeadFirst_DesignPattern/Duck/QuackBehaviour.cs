namespace DuckConsole;

public class Quack : IQuackBehaviour
{
    public virtual void quack()
    {
        System.Console.WriteLine("Quack");
    }
}

public class MuteQuack : IQuackBehaviour
{
    public virtual void quack()
    {
        System.Console.WriteLine("<< Silence >>");
    }
}

public class Squeak : IQuackBehaviour
{
    public virtual void quack()
    {
        System.Console.WriteLine("Squeak");
    }
}