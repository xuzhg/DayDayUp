namespace DecoratorNs;

public abstract class Beverage
{
    protected string description = "Unknown Beverage";

   // protected Beverage() {}

   // protected Beverage(string desp) => description = desp;

    public virtual string GetDescription() => description;

    public abstract double cost();
}

public class HouseBlend : Beverage
{
    public HouseBlend()
    {
        description = "House Blend";
    }

    public override double cost()
    {
        return 0.89;
    }
}

public class DarkRoast : Beverage
{
    public DarkRoast()
    {
        description = "Dark Roast";
    }
    
    public override double cost()
    {
        return 0.99;
    }
}

public class Espresso : Beverage
{
    public Espresso()
    {
        description = "Espresso";
    }
    
    public override double cost()
    {
        return 1.99;
    }
}

public class Decaf : Beverage
{
    public Decaf()
    {
        description = "Decaf";
    }
    
    public override double cost()
    {
        return 1.05;
    }
}