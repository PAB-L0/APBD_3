namespace Labs_3.Interfaces;

public interface IHazardNotifier
{
    public void Notify(string serialNumber, string warningMessage);
}