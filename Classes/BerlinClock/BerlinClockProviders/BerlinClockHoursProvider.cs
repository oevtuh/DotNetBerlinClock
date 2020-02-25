using System;
using System.Collections.Generic;
using System.Text;

namespace BerlinClock.Classes.BerlinClock.BerlinClockProviders
{
    public class BerlinClockHoursProvider : ITimeBlockProvider
    {
        public string GetTimeBlock(int hours)
        {
            int topHours = hours / Constants.HOURS_INTERVAL;
            int buttonHours = hours % Constants.HOURS_INTERVAL;

            String topRow = GetHoursRow(Constants.TOP_HOURS_BLOCK_LENGTH, topHours);
            String bottomRow = GetHoursRow(Constants.BOTTOM_HOURS_BLOCK_LENGTH, buttonHours);

            return String.Format("{0}\r\n{1}", topRow, bottomRow);
        }

        /// <summary>
        /// Returns the light for  hour row. 
        /// </summary>
        /// <param name="blockLength"></param>
        /// <param name="activeLights"></param>
        /// <returns></returns>

        private string GetHoursRow(int blockLength, int activeLights)
        {
            StringBuilder row = new StringBuilder();

            for (var i = 0; i < blockLength; i++)
            {
                row.Append(i < activeLights ? Constants.RED_LIGHT : Constants.EMPTY_LIGHT);
            }

            return row.ToString();
        }
    }
}