using BerlinClock.Classes.BerlinClock.BerlinClockProviders;

namespace BerlinClock
{
    public class BerlinClockConverter : IBerlinClock
    {
        private ITimeBlockProvider _secondsTimeBlockProviders;
        private ITimeBlockProvider _minutesTimeBlockProviders;
        private ITimeBlockProvider _hoursTimeBlockProviders;
        private ITimeBlockProviderFactory _timeBlockProviderFactory;

        public BerlinClockConverter(ITimeBlockProviderFactory timeBlockProviderFactory)
        {
            _timeBlockProviderFactory = timeBlockProviderFactory;

            _timeBlockProviderFactory = timeBlockProviderFactory;
            _secondsTimeBlockProviders = _timeBlockProviderFactory.CreateSecondsTimeBlockProvider();
            _minutesTimeBlockProviders = _timeBlockProviderFactory.CreateMinutesTimeBlockProvider();
            _hoursTimeBlockProviders = _timeBlockProviderFactory.CreateHoursTimeBlockProvider();
        }
        public string ConvertTime(Time time)
        {
            int hours = time.Hours;
            int minutes = time.Minutes;
            int seconds = time.Seconds;

            return string.Format("{0}\r\n{1}\r\n{2}", _secondsTimeBlockProviders.GetTimeBlock(seconds), _hoursTimeBlockProviders.GetTimeBlock(hours), _minutesTimeBlockProviders.GetTimeBlock(minutes));
        }
    }
}