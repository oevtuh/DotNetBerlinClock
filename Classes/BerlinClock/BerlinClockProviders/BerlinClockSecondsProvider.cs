namespace BerlinClock.Classes.BerlinClock.BerlinClockProviders
{
    public class BerlinClockSecondsProvider : ITimeBlockProvider
    {
        /// <summary>
        /// Returns the light for seconds.
        /// </summary>
        /// <param name="sec"></param>
        /// <returns></returns>
        public string GetTimeBlock(int sec)
        {
            return sec % Constants.SECONDS_INTERVAL == 0 ? Constants.YELLOW_LIGTH : Constants.EMPTY_LIGHT;
        }
    }
}