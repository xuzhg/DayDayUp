namespace WeatherNs;

public interface ISubject
{
    void registerObserver(IObserver o);
    void removeObservers(IObserver o);

    void notifyObservers();
}