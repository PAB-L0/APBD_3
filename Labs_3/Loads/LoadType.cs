namespace Labs_3.Loads;

public class LoadType(string name, double storingTemperature)
{
    public string Name { get; } = name;
    public double StoringTemperature { get; } = storingTemperature;

    public override string ToString()
    {
        return $"{Name}, Storing temperature: {StoringTemperature} \u00b0C";
    }
}