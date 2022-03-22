using System;
using System.Collections.Generic;

namespace PizzaNs;

public class NYStyleCheesePizza : Pizza
{
    public NYStyleCheesePizza()
    {
        Name = "NY Style Sauce and Cheese Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano Cheese");
    }
}

public class NYStyleVeggiePizza : Pizza
{
    public NYStyleVeggiePizza()
    {
        Name = "NY Style Sauce and Veggie Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano Cheese");
    }
}

public class NYStyleClamPizza : Pizza
{
    public NYStyleClamPizza()
    {
        Name = "NY Style Sauce and Clam Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano Cheese");
    }
}

public class NYStylePepperoniPizza : Pizza
{
    public NYStylePepperoniPizza()
    {
        Name = "NY Style Sauce and Pepperoni Pizza";
        Dough = "Thin Crust Dough";
        Sauce = "Marinara Sauce";
        Toppings.Add("Grated Reggiano Cheese");
    }
}