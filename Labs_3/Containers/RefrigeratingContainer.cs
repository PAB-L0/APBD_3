using Labs_3.Exceptions;
using Labs_3.Interfaces;
using Labs_3.Loads;

namespace Labs_3.Containers;

public class RefrigeratingContainer(double height, double depth, double mass, double maximalLoadMass, string type = "C") : Container(height, depth, mass, maximalLoadMass, type), IHazardNotifier
{
    private LoadType _loadTypeType = new LoadType("None", 0);
    private double _temperature;

    public LoadType LoadType
    {
        get => _loadTypeType;
        set
        {
            if (CurrentLoadMass != 0)
            {
                Notify(SerialNumber, "Load type modification attempt, there's a load in the container.");
            }
            else
            {
                _loadTypeType = value;
            }
        }
    }
    public double Temperature
    {
        get => _temperature;
        set
        {
            if (CurrentLoadMass != 0)
            {
                Notify(SerialNumber, "Container temperature modification attempt, there is a load in the container.");
            }
            else
            {
                _temperature = value;
            }
        }
    }
    
    public void Load(LoadType loadType, double loadMass)
    {
        if (LoadType.Name != loadType.Name && LoadType.Name != "None")
        {
            throw new ArgumentException("Load types must be the same.");
        }
        if (Temperature < loadType.StoringTemperature)
        {
            Notify(SerialNumber, "Load temperature is too high.");
        }
        else if (loadMass <= 0)
        {
            throw new ArgumentException("Load mass must be positive.");
        }
        else if (CurrentLoadMass + loadMass <= MaximalLoadMass)
        {
            LoadType = loadType;
            CurrentLoadMass += loadMass;
        }
        else
        {
            throw new OverfillException("Load mass is too much, there's not enough space in the container.");
        }
    }

    public override void Load(double loadMass) {}

    public override void Unload()
    {
        base.Unload();
        LoadType = new LoadType("None", 0);
        Temperature = 0;
    }

    public void Notify(string serialNumber, string warningMessage)
    {
        Console.WriteLine("Container's serial number: " + serialNumber + ": " + warningMessage);
    }
    
    public override string ToString()
    {
        return base.ToString() + $"Load Type: {LoadType}.\n" + $"Temperature: {Temperature} \u00b0C.";
    }
}