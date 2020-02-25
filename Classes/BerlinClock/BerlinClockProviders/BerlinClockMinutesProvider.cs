using System;
using System.Text;

namespace BerlinClock.Classes.BerlinClock.BerlinClockProviders
{
    public class BerlinClockMinutesProvider : ITimeBlockProvider
    {
        /// <summary>
        ///  Returns the light for minutes
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        public string GetTimeBlock(int minutes)
        {
            int topMinutes = minutes / Constants.MINUTES_INTERVAL;
            int buttonMinutes = minutes % Constants.MINUTES_INTERVAL;

            var topRow = GetMinutesRow(Constants.TOP_MINUTES_BLOCK_LENGTH, topMinutes, i => (i + 1) % 3 == 0);
            var bottomRow = GetMinutesRow(Constants.BOTTOM_MINUTES_BLOCK_LENGTH, buttonMinutes,
                i => false);

            return String.Format("{0}\r\n{1}", topRow, bottomRow);
        }

        /// <summary>
        /// Returns the light for  minute row. 
        /// </summary>
        /// <param name="blockLength"></param>
        /// <param name="activeLights"></param>
        /// <param name="topRowDefiner">Defines different func for getting red lamp and indicate the first quarter, half and last quarter of an hour. If the minutes line is not related to quarter and should return yellow light - pass i=> true</param>
        /// <returns></returns>
        private string GetMinutesRow(int blockLength, int activeLights, Func<int, bool> topRowDefiner)
        {
            StringBuilder row = new StringBuilder();

            for (var i = 0; i < blockLength; i++)
            {
                row.Append(i < activeLights ? (topRowDefiner(i) ? Constants.RED_LIGHT : Constants.YELLOW_LIGTH) : Constants.EMPTY_LIGHT);
            }

            return row.ToString();
        }
    }
}