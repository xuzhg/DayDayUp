namespace DuckConsole;

public class ModelDuck : Duck
{
    public ModelDuck()
    {
        _quackBehaviour = new Quack();
        _flyBehaviour = new FlyNoWay();
    }

    public override void display()
    {
        System.Console.WriteLine("I'm a model duck.");
    }
}