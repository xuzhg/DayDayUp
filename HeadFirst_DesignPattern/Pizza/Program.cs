using System;

namespace PizzaNs;

public class Program
{
    public static void Main(string[] args)
    {
        PizzaStore nyStore = new NYStylePizzaStore();
        PizzaStore chicagoStore = new ChicagoPizzaStore();

        Pizza pizza = nyStore.OrderPizza("cheese");
        Console.WriteLine("Ethan ordered a " + pizza.Name + "\n");

        pizza = chicagoStore.OrderPizza("cheese");
        Console.WriteLine("Joel ordered a " + pizza.Name + "\n");
    }
}