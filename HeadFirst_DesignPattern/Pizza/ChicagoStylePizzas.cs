using System;
using System.Collections.Generic;

namespace PizzaNs;

public class ChicagoStyleCheesePizza : Pizza
{
    public ChicagoStyleCheesePizza()
    {
        Name = "Chicago Style Deep Dish Cheese Pizza";
        Dough = "Extra Thick Crust Dough";
        Sauce = "Plum Tomato Sauce";
        Toppings.Add("Shredded Mozarella Cheese");
    }

    public override void Cut()
    {
        Console.WriteLine("Cutting the piza into square slices");
    }
}

public class ChicagoStyleVeggiePizza : Pizza
{
    public ChicagoStyleVeggiePizza()
    {
        Name = "Chicago Style Deep Dish Veggie Pizza";
        Dough = "Extra Thick Crust Dough";
        Sauce = "Plum Tomato Sauce";
        Toppings.Add("Shredded Mozarella Cheese");
    }

    public override void Cut()
    {
        Console.WriteLine("Cutting the piza into square slices");
    }
}
