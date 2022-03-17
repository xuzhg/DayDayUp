namespace WeatherNs;

public class StatisticsDisplay : IObserver, IDisplayElement
{
    private float maxTemp = 0.0f;
    private float minTemp = 200f;
    private float tempSum = 0.0f;
    private int numReadings = 0;

    private WeatherData weatherData;

    public StatisticsDisplay(WeatherData weatherData)
    {
        this.weatherData = weatherData;
        weatherData.registerObserver(this);
    }

    public void update()
    {
        float temp = weatherData.Temperature;
        tempSum += temp;
        ++numReadings;

        if (temp > maxTemp){
            maxTemp = temp;
        }

        if (temp < minTemp){
            minTemp = temp;
        }

        display();
    }

    public void display()
    {
        System.Console.WriteLine("Avg/Max/Min temperature : " + (tempSum / numReadings) + "/" + maxTemp + "/" + minTemp);
    }
}