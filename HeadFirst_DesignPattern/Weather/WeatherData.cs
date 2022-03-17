using System.Collections.Generic;
namespace WeatherNs;

public class WeatherData : ISubject
{
    private List<IObserver> observers;
    private float temperature;
    private float humidity;
    private float pressure;

    public WeatherData()
    {
        observers = new List<IObserver>();
    }

    public float Temperature => temperature;

    public float Humidity => humidity;

    public float Pressure => pressure;

    public void registerObserver(IObserver o)
    {
        observers.Add(o);
    }
    public void removeObservers(IObserver o)
    {
        observers.Remove(o);
    }

    public void notifyObservers()
    {
        foreach (var observer in observers)
        {
            // observer.update(temperature, humidity, pressure);
            observer.update();
        }
    }

    public void measurementsChanged(){
        notifyObservers();
    }

    public void setMeasurements(float temperature, float humidity, float pressure)
    {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pressure = pressure;

        measurementsChanged();
    }
}