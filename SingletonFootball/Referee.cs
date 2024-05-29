namespace SingletonFootball;

public class Referee
{
    private static Referee instance;
    public string Name { get; set; }

    private static readonly object _lock = new object();

    private Referee()
    {

    }

    public static Referee GetInstance(string value)
    {
        if (instance == null)
        {
            lock (_lock)
            {
                if (instance == null)
                {
                    instance = new Referee();
                    instance.Name = value;
                }
            }
        } 
        return instance;
    } 
}
