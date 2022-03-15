namespace DuckConsole;

public abstract class Duck
{
    protected IQuackBehaviour _quackBehaviour;
    protected IFlyBehaviour _flyBehaviour;

    public Duck()
    {

    }

    public abstract void display();

    public void performFly()
    {
        _flyBehaviour.fly();
    }

    public void setFlyBehaviour(IFlyBehaviour flyBehaviour)
    {
        _flyBehaviour = flyBehaviour;
    }

    public void performQuack()
    {
        _quackBehaviour.quack();
    }

    public void setQuackBehaviour(IQuackBehaviour quackBehaviour)
    {
        _quackBehaviour = quackBehaviour;
    }

    public void swim()
    {
        System.Console.WriteLine("All ducks float, even decoys!");
    }
}