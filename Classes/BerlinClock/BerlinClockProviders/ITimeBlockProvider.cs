namespace BerlinClock.Classes.BerlinClock.BerlinClockProviders
{
    public interface ITimeBlockProvider
    {
        string GetTimeBlock(int timeAmount);
    }
}