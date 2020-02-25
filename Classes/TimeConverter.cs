using System;
using System.Text;
using System.Text.RegularExpressions;
using BerlinClock.Classes.BerlinClock.BerlinClockProviders;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private ITimeStringValidator _timeValidator;
        private IBerlinClock _clock;

        public TimeConverter(ITimeStringValidator timeValidator, IBerlinClock clock)
        {
            _timeValidator = timeValidator;
            _clock = clock;

        }

        /// <summary>
        /// Converts Time from original format HH:mm:ss to BerlinClock.
        /// </summary>
        /// <param name="aTime"></param>
        /// <returns></returns>
        public string ConvertTime(string aTime)
        {
            var validation = _timeValidator.ValidateTimeString(aTime);
            if (!validation.Valid)
            {
                throw new ArgumentException("Invalid time format. Time format must be HH:mm:ss");
            }

            return _clock.ConvertTime(validation.Time);
        }
    }
}
