using Labs_3.Exceptions;
using Labs_3.Interfaces;

namespace Labs_3.Containers;

public class LiquidContainer(double height, double depth, double mass, double maximalLoadMass, string type = "L") : Container(height, depth, mass, maximalLoadMass, type), IHazardNotifier
{
    private bool _loadSafe;
    public bool LoadSafe
    {
        get => _loadSafe;
        set
        {
            if (CurrentLoadMass != 0)
            {
                Notify(SerialNumber, "Load safety modification attempt, there's a load in the container.");
            }
            else
            {
                _loadSafe = value;
            }
        }
    }

    public override void Load(double loadMass)
    {
        if (loadMass <= 0)
        {
            throw new ArgumentException("Load mass must be positive.");
        }
        if (CurrentLoadMass + loadMass <= 0.5 * MaximalLoadMass && !LoadSafe || CurrentLoadMass + loadMass <= 0.9 * MaximalLoadMass && LoadSafe)
        {
            CurrentLoadMass += loadMass;
        }
        else if (CurrentLoadMass + loadMass <= MaximalLoadMass)
        {
            Notify(SerialNumber, "Load mass modification attempt, violation of load safety.");
        }
        else
        {
            throw new OverfillException("Load mass is too much, there's not enough space in the container.");
        }
    }

    public override void Unload()
    {
        base.Unload();
        LoadSafe = false;
    }
    
    public void Notify(string serialNumber, string warningMessage)
    {
        Console.WriteLine("Container's serial number: " + serialNumber + ": " + warningMessage);
    }

    public override string ToString()
    {
        return base.ToString() + "Load safety: " + (LoadSafe ? "Safe." : "Dangerous.");
    }
}