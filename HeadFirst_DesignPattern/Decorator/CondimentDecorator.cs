namespace DecoratorNs;

public abstract class CondimentDecorator : Beverage
{
    protected CondimentDecorator(Beverage beverage) 
    {
        Beverage = beverage;
    }

     public Beverage Beverage { get; }

   // public abstract string GetDescription();
}

public class Milk : CondimentDecorator
{
    public Milk(Beverage beveraged) : base(beveraged){}

    public override string GetDescription() {
        return Beverage.GetDescription() + ", Milk";
    }

    public override double cost()
    {
        return Beverage.cost() + 0.1;
    }
}

public class Mocha : CondimentDecorator
{
    public Mocha(Beverage beveraged) : base(beveraged){}

    public override string GetDescription() {
        return Beverage.GetDescription() + ", Mocha";
    }

    public override double cost()
    {
        return Beverage.cost() + 0.2;
    }
}

public class Whip : CondimentDecorator
{
    public Whip(Beverage beveraged) : base(beveraged){}

    public override string GetDescription() {
        return Beverage.GetDescription() + ", Whip";
    }

    public override double cost()
    {
        return Beverage.cost() + 0.1;
    }
}

public class Soy : CondimentDecorator
{
    public Soy(Beverage beveraged) : base(beveraged){}

    public override string GetDescription() {
        return Beverage.GetDescription() + ", Soy";
    }

    public override double cost()
    {
        return Beverage.cost() + 0.15;
    }
}