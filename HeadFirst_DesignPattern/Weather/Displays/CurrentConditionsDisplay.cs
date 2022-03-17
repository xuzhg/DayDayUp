namespace WeatherNs;

public class CurrentConditionsDisplay : IObserver, IDisplayElement
{
    private float temperature;
    private float humidity;

    private WeatherData weatherData;

    public CurrentConditionsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.registerObserver(this);
    }

    // public void update(float temperature, float humidity, float pressure)
    public void update()
    {
        this.temperature = weatherData.Temperature;
        this.humidity = weatherData.Humidity;
      //  this.pressure = pressure;
        display();
    }

    public void display()
    {
        System.Console.WriteLine("Current conditions: " + this.temperature + "F degrees and " + this.humidity + "% humidity");
    }
}