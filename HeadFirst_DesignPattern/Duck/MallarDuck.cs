namespace DuckConsole;

public class MallarDuck : Duck
{
    public MallarDuck()
    {
        _quackBehaviour = new Quack();
        _flyBehaviour = new FlyWithWings();
    }

    public override void display()
    {
        System.Console.WriteLine("I'm a real mullar duck.");
    }
}