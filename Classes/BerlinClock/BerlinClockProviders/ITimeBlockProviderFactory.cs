namespace BerlinClock.Classes.BerlinClock.BerlinClockProviders
{
    public interface ITimeBlockProviderFactory
    {
        ITimeBlockProvider CreateSecondsTimeBlockProvider();
        ITimeBlockProvider CreateMinutesTimeBlockProvider();
        ITimeBlockProvider CreateHoursTimeBlockProvider();
    }
}