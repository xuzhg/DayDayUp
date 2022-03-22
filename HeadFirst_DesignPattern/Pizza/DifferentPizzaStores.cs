namespace PizzaNs;

public class NYStylePizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        if (type == "cheese"){
            return new NYStyleCheesePizza();
        }
        else if (type == "veggie"){
            return new NYStyleVeggiePizza();
        }
        else if (type == "clam"){
            return new NYStyleClamPizza();
        }
        else if (type == "pepperoni"){
            return new NYStylePepperoniPizza();
        }
        else
            return null;
    }
}

public class ChicagoPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        if (type == "cheese"){
            return new ChicagoStyleCheesePizza();
        }
        else if (type == "veggie"){
            return new ChicagoStyleVeggiePizza();
        }
     //   else if (type == "clam"){
     //       return new NYStyleClamPizza();
     //   }
     //   else if (type == "pepperoni"){
     //       return new NYStylePepperoniPizza();
    //    }
        else
            return null;
    }
}

