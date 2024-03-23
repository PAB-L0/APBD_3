using Labs_3.Containers;
using Labs_3.Loads;
using Labs_3.Ships;

var liquidContainer = new LiquidContainer(250, 1000, 1000, 2500);
Console.WriteLine(liquidContainer + "\n");
liquidContainer.LoadSafe = true;
liquidContainer.Load(2000);
Console.WriteLine(liquidContainer + "\n");
liquidContainer.Unload();
Console.WriteLine(liquidContainer + "\n");

var gasContainer = new GasContainer(500, 2000, 1000, 5000);
Console.WriteLine(gasContainer + "\n");
gasContainer.LoadPressure = 1250;
gasContainer.Load(5000);
Console.WriteLine(gasContainer + "\n");
gasContainer.Unload();
Console.WriteLine(gasContainer + "\n");

var refrigeratingContainer = new RefrigeratingContainer(750, 3000, 1000, 7500);
Console.WriteLine(refrigeratingContainer + "\n");
refrigeratingContainer.Temperature = -10;
refrigeratingContainer.Load(new LoadType("Apple", -25), 5000);
Console.WriteLine(refrigeratingContainer + "\n");
refrigeratingContainer.Unload();
Console.WriteLine(refrigeratingContainer + "\n");

var containerShip = new Ship(25, 50, 100);
Console.WriteLine(containerShip);
containerShip.LoadContainer(liquidContainer);
Console.WriteLine(containerShip);
var containers = new List<Container>(2)
{
    gasContainer,
    refrigeratingContainer
};
containerShip.LoadContainers(containers);
Console.WriteLine(containerShip);
containerShip.RemoveContainer(refrigeratingContainer);
Console.WriteLine(containerShip);
containerShip.ReplaceContainer(liquidContainer.SerialNumber, refrigeratingContainer);
Console.WriteLine(containerShip);
var otherContainerShip = new Ship(25, 50, 100);
Console.WriteLine(otherContainerShip);
containerShip.MoveContainer(otherContainerShip, refrigeratingContainer);
Console.WriteLine(containerShip);
Console.WriteLine(otherContainerShip);