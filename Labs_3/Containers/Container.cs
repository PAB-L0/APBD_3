using Labs_3.Exceptions;

namespace Labs_3.Containers;

public abstract class Container(double height, double depth, double mass, double maximalLoadMass, string type = "?")
{
    private static int _identifier = 1;

    public string SerialNumber { get; } = "CON-" + type + $"-{_identifier++}";
    
    private double Height { get; } = height;
    private double Depth { get; } = depth;
    
    public double Mass { get; } = mass;
    public double MaximalLoadMass { get; } = maximalLoadMass;
    
    protected double CurrentLoadMass { get; set; }

    public virtual void Load(double loadMass)
    {
        if (loadMass <= 0)
        {
            throw new ArgumentException("Load mass must be positive.");
        }
        if (CurrentLoadMass + loadMass <= MaximalLoadMass)
        {
            CurrentLoadMass += loadMass;
        }
        else
        {
            throw new OverfillException("Load mass is too much, there's not enough space in the container.");
        }
    }

    public virtual void Unload()
    {
        CurrentLoadMass = 0;
    }
    
    public override string ToString()
    {
        return $"Container's serial number: {SerialNumber}:\n" +
               $"Measurements: {Height} cm x {Depth} cm.\n" +
               $"Mass: {Mass} kg.\n" +
               $"Maximal Load Mass: {MaximalLoadMass} kg.\n" +
               $"Current Load Mass: {CurrentLoadMass} kg.\n";
    }
}