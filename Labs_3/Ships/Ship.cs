using Labs_3.Containers;
using Labs_3.Exceptions;

namespace Labs_3.Ships;

public class Ship(double maximalSpeed, int maximalContainersAmount, double maximalContainersMass)
{
    private double MaximalSpeed { get; } = maximalSpeed;
    private int MaximalContainersAmount { get; } = maximalContainersAmount;
    private int CurrentContainersAmount { get; set; }
    private double MaximalContainersMass { get; } = maximalContainersMass * 1000;
    private double CurrentMaximalContainersMass { get; set; }
    private List<Container> Containers { get; } = new(maximalContainersAmount);
    
    public void LoadContainer(Container containerToLoad)
    {
        if (CurrentContainersAmount < MaximalContainersAmount &&
            CurrentMaximalContainersMass + containerToLoad.Mass + containerToLoad.MaximalLoadMass <= MaximalContainersMass)
        {
            Containers.Add(containerToLoad);
            CurrentContainersAmount++;
            CurrentMaximalContainersMass += (containerToLoad.Mass + containerToLoad.MaximalLoadMass);
        }
        else
        {
            throw new OverfillException("Potential breach of the ship limits.");
        }
    }

    public void LoadContainers(List<Container> containersToLoad)
    {
        foreach (var containerToLoad in containersToLoad)
        {
            LoadContainer(containerToLoad);
        }
    }

    public void RemoveContainer(Container containerToRemove)
    {
        if (Containers.Remove(containerToRemove))
        {
            CurrentContainersAmount--;
            CurrentMaximalContainersMass -= (containerToRemove.Mass + containerToRemove.MaximalLoadMass);
        }
        else
        {
            throw new ArgumentException("Container isn't on the ship board.");
        }
    }

    public void ReplaceContainer(string containerSerialNumber, Container containerToInsert)
    {
        var containerToReplace = Containers.Find(container => container.SerialNumber == containerSerialNumber) ??
                                       throw new ArgumentException("Container isn't on the ship board.");
        RemoveContainer(containerToReplace);
        LoadContainer(containerToInsert);
    }

    public void MoveContainer(Ship shipToMoveTo, Container containerToMove)
    {
        RemoveContainer(containerToMove);
        shipToMoveTo.LoadContainer(containerToMove);
    }

    public override string ToString()
    {
        var result = $"Container ship statistics:\n" + 
                     $"Maximal Speed: {MaximalSpeed} Knots.\n" + 
                     $"Maximal Containers Amount: {MaximalContainersAmount}.\n" + 
                     $"Current Containers Amount: {CurrentContainersAmount}.\n" + 
                     $"Maximal Containers Mass: {MaximalContainersMass} kg.\n" + 
                     $"Current Maximal Containers Mass: {CurrentMaximalContainersMass} kg.\n" + 
                     $"Onboard containers:\n";
        if (CurrentContainersAmount == 0)
            result += "None.\n";
        else
        {
            foreach (var container in Containers)
            {
                result += container + "\n";
            }    
        }
        return result;
    }
}