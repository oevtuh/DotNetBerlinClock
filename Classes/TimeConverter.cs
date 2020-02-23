using System;
using System.Text;
using System.Text.RegularExpressions;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private const string RED_LIGHT = "R";
        private const string YELLOW_LIGTH = "Y";
        private const string EMPTY_LIGHT = "O";

        private const int TOP_HOURS_BLOCK_LENGTH = 4;
        private const int BOTTOM_HOURS_BLOCK_LENGTH = 4;

        private const int TOP_MINUTES_BLOCK_LENGTH = 11;
        private const int BOTTOM_MINUTES_BLOCK_LENGTH = 4;

        private const int SECONDS_INTERVAL = 2;
        private const int MINUTES_INTERVAL = 5;
        private const int HOURS_INTERVAL = 5;

        /// <summary>
        /// Converts Time from original format HH:mm:ss to BerlinClock.
        /// </summary>
        /// <param name="aTime"></param>
        /// <returns></returns>
        public string ConvertTime(string aTime)
        {
            if (!IsTimeFormatValid(aTime))
            {
                throw new AggregateException("Invalid time format.Time format must be HH:mm:ss");
            }
            int hours = int.Parse(aTime.Split(':')[0]);
            int minutes = int.Parse(aTime.Split(':')[1]);
            int seconds = int.Parse(aTime.Split(':')[2]);

            return string.Format("{0}\r\n{1}\r\n{2}", GetSeconds(seconds), GetHours(hours), GetMinutes(minutes));
        }

        /// <summary>
        /// Returns the light for seconds.
        /// </summary>
        /// <param name="sec"></param>
        /// <returns></returns>
        private string GetSeconds(int sec)
        {
            return sec % SECONDS_INTERVAL == 0 ? YELLOW_LIGTH : EMPTY_LIGHT;
        }

        /// <summary>
        ///  Returns the light for minutes
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        private string GetMinutes(int minutes)
        {
            int topMinutes = minutes / MINUTES_INTERVAL;
            int buttonMinutes = minutes % MINUTES_INTERVAL;

            var topRow = GetMinutesRow(TOP_MINUTES_BLOCK_LENGTH, topMinutes, i=> (i + 1) % 3 == 0);
            var bottomRow = GetMinutesRow(BOTTOM_MINUTES_BLOCK_LENGTH, buttonMinutes,
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
                row.Append(i < activeLights ? (topRowDefiner(i) ? RED_LIGHT : YELLOW_LIGTH) : EMPTY_LIGHT);
            }

            return row.ToString();
        }
        /// <summary>
        /// Returns the light for hours.
        /// </summary>
        /// <param name="hours"></param>
        /// <returns></returns>
        private string GetHours(int hours)
        {
            int topHours = hours / HOURS_INTERVAL;
            int buttonHours = hours % HOURS_INTERVAL;

            String topRow = GetHoursRow(TOP_HOURS_BLOCK_LENGTH, topHours);
            String bottomRow = GetHoursRow(BOTTOM_HOURS_BLOCK_LENGTH, buttonHours);
            
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
                row.Append(i < activeLights ? RED_LIGHT : EMPTY_LIGHT);
            }

            return row.ToString();
        }

        /// <summary>
        /// Validates input time string. Format should be HH:mm:ss. Because .Net DateTime doesn't support 24:00:00 - the additional check added.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private bool IsTimeFormatValid(string input)
        {
            var match = Regex.Match(input, @"(?:[01]\d|2[0123]):(?:[012345]\d):(?:[012345]\d)", RegexOptions.IgnoreCase);

            return match.Success || input == "24:00:00";
        }
    }
}
