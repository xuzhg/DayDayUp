namespace WeatherNs;

public class ForecastDisplay : IObserver, IDisplayElement
{
    private float currentPressure = 29.92f;
    private float lastPressure;
    private WeatherData weatherData;

    public ForecastDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.registerObserver(this);
    }

    public void update()
    {
        lastPressure = currentPressure;
        currentPressure = weatherData.Pressure;
        display();
    }

    public void display()
    {
        System.Console.Write("Forecast: ");

        if (currentPressure > lastPressure)
        {
            System.Console.WriteLine("Improving weather on the way!");
        }
        else if (currentPressure == lastPressure)
        {
            System.Console.WriteLine("More of the same!");
        }
        else
        {
            System.Console.WriteLine("Watch out for  cooler, rainy weather");
        } 
    }
}