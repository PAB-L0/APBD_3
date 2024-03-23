using Labs_3.Interfaces;

namespace Labs_3.Containers;

public class GasContainer(double height, double depth, double mass, double maximalLoadMass, string type = "G") : Container(height, depth, mass, maximalLoadMass, type), IHazardNotifier
{
    private int _loadPressure;
    public int LoadPressure
    {
        get => _loadPressure;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Load pressure must be positive.");
            }
            _loadPressure = value;
        }
    }
    
    public override void Unload()
    {
        CurrentLoadMass *= 0.05;
    }

    public void Notify(string serialNumber, string warningMessage)
    {
        Console.WriteLine("Container's serial number: " + serialNumber + ": " + warningMessage);
    }

    public override string ToString()
    {
        return base.ToString() + $"Load Pressure: {LoadPressure} Pa.";
    }
}