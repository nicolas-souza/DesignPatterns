namespace SingletonFootball;

public class Ball
{
    private static Ball instance;
    public string ImagePath { get; set; }
    public string Weight { get; set; }
    public double ElasticCoefficient { get; set; }

    private Ball()
    {

    }

    public static Ball GetInstance()
    {
        instance ??= new Ball(); // if instance is null than it receives new Ball()
        
        return instance;
    }

}
