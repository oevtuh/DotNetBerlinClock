namespace BerlinClock.Classes.BerlinClock.BerlinClockProviders
{
    public class TimeBlockProviderFactory : ITimeBlockProviderFactory
    {
        public ITimeBlockProvider CreateSecondsTimeBlockProvider()
        {
            return new BerlinClockSecondsProvider();
        }

        public ITimeBlockProvider CreateMinutesTimeBlockProvider()
        {
            return new BerlinClockMinutesProvider();
        }

        public ITimeBlockProvider CreateHoursTimeBlockProvider()
        {
            return new BerlinClockHoursProvider();
        }
    }
}