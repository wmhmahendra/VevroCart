using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CART_Common
{
    public static class DateTimeHelper
    {
        #region Properties

        /// <summary>
        /// Gets the minimum date.
        /// </summary>
        /// <value>
        /// The minimum date.
        /// </value>
        public static DateTime MinDate
        {
            get
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// Get current date and time form datetime helper.
        /// </summary>
        public static DateTime Now
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Gets the yesterday.
        /// </summary>
        /// <value>
        /// The yesterday.
        /// </value>
        public static DateTime Yesterday
        {
            get
            {
                return DateTime.Now.AddDays(-1).Date;
            }
        }

        /// <summary>
        /// Gets the last7 days.
        /// </summary>
        /// <value>
        /// The last7 days.
        /// </value>
        public static DateRange Last7Days
        {
            get
            {
                return GetLast7Days();
            }
        }

        /// <summary>
        /// Gets the last week.
        /// </summary>
        /// <value>
        /// The last week.
        /// </value>
        public static DateRange LastWeek
        {
            get
            {
                return GetLastWeek();
            }
        }

        /// <summary>
        /// Gets the last month.
        /// </summary>
        /// <value>
        /// The last month.
        /// </value>
        public static DateRange LastMonth
        {
            get
            {
                return GetLastMonth();
            }
        }

        /// <summary>
        /// Gets the last30 days.
        /// </summary>
        /// <value>
        /// The last30 days.
        /// </value>
        public static DateRange Last30Days
        {
            get
            {
                return GetLast30Days();
            }
        }

        /// <summary>
        /// Defines the date range struct
        /// </summary>
        public struct DateRange
        {
            /// <summary>
            /// Gets or sets the start.
            /// </summary>
            /// <value>
            /// The start.
            /// </value>
            public DateTime Start
            {
                get;
                set;
            }

            /// <summary>
            /// Gets or sets the end.
            /// </summary>
            /// <value>
            /// The end.
            /// </value>
            public DateTime End
            {
                get;
                set;
            }
        }

        #endregion Properties

        #region Public Fuinctionalities

        /// <summary>
        /// Formats the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        /// Returns the formatted date.
        /// </returns>
        public static string FormatDate(DateTime date)
        {
            return string.Format("{0:MMMM dd, yyyy}", date);
        }


        /// <summary>
        /// Formats the date.
        /// </summary>
        /// <param name="date">nullable The date.</param>
        /// <returns>
        /// Returns the formatted date.
        /// </returns>
        public static string FormatDate(DateTime? date)
        {
            return string.Format("{0:MMMM dd, yyyy h:mm tt}", date);
        }

        /// <summary>
        /// Formats the date with time.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static string FormatDateWithTime(DateTime date)
        {
            return string.Format("{0:MMMM dd, yyyy, h:mm tt}", date);
        }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <param name="timeInMiliseconds">The time in milliseconds.</param>
        /// <returns></returns>
        public static string GetTime(int timeInMilliseconds)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(timeInMilliseconds);

            StringBuilder timeString = new StringBuilder();

            if (t.Hours > 0)
            {
                timeString.Append(t.Hours);
                timeString.Append(" ");
                timeString.Append("h");
                timeString.Append(" ");
            }
            if (t.Minutes > 0)
            {
                timeString.Append(t.Minutes);
                timeString.Append(" ");
                timeString.Append("m");
                timeString.Append(" ");
            }
            if (t.Seconds > 0)
            {
                timeString.Append(t.Seconds);
                timeString.Append(" ");
                timeString.Append("s");
                timeString.Append(" ");
            }
            if (t.Hours == 0 && t.Minutes == 0 && t.Seconds == 0)
            {
                timeString.Append("-");
            }

            return timeString.ToString();
        }

        public static string GettimewithDays(int minits)
        {
            TimeSpan t = TimeSpan.FromMinutes(minits);

            StringBuilder timeString = new StringBuilder();

            if (t.Days > 0)
            {
                timeString.Append(t.Days);
                timeString.Append(" ");
                timeString.Append("d");
                timeString.Append(" ");
            }
            if (t.Hours > 0)
            {
                timeString.Append(t.Hours);
                timeString.Append(" ");
                timeString.Append("h");
                timeString.Append(" ");
            }
            if (t.Minutes > 0)
            {
                timeString.Append(t.Minutes);
                timeString.Append(" ");
                timeString.Append("m");
                timeString.Append(" ");
            }

            if (t.Hours == 0 && t.Minutes == 0 && t.Seconds == 0)
            {
                timeString.Append("-");
            }

            return timeString.ToString();
        }

        /// <summary>
        /// Gets the time.
        /// </summary>
        /// <param name="timeInMiliseconds">The time in milliseconds.</param>
        /// <returns></returns>
        public static string GetTimeWithoutSecond(int timeInMilliseconds)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(timeInMilliseconds);

            StringBuilder timeString = new StringBuilder();

            timeString.Append(t.Hours);
            timeString.Append(" ");
            timeString.Append("hr(s)");
            timeString.Append(" ");
            timeString.Append(t.Minutes);
            timeString.Append(" ");
            timeString.Append("min(s)");
            timeString.Append(" ");

            return timeString.ToString();
        }

        /// <summary>
        /// Gets the date difference.
        /// </summary>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <returns>
        /// Returns the date different in between two dates.
        /// </returns>
        public static int GetDateDiff(DateTime firstDate, DateTime secondDate)
        {
            return (firstDate - secondDate).Days;
        }

        /// <summary>
        /// Gets the last30 days.
        /// </summary>
        /// <returns>
        /// Returns last 30 days range.
        /// </returns>
        private static DateRange GetLast30Days()
        {
            DateTime date = Now;

            DateRange range = new DateRange();

            range.Start = date.AddDays(-30).Date;
            range.End = date.Date;

            return range;
        }

        /// <summary>
        /// Lasts the month.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private static DateRange GetLastMonth()
        {
            DateTime date = Now;

            DateRange range = new DateRange();

            range.Start = (new DateTime(date.Year, date.Month, 1)).AddMonths(-1).Date;
            range.End = range.Start.AddMonths(1).AddSeconds(-1).Date;

            return range;
        }

        /// <summary>
        /// Lasts the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private static DateRange GetLast7Days()
        {
            DateTime date = Now;

            DateRange range = new DateRange();

            range.Start = date.AddDays(-7).Date;
            range.End = date.Date;

            return range;
        }

        /// <summary>
        /// Lasts the week.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        private static DateRange GetLastWeek()
        {
            DateTime date = Now;

            DateRange range = ThisWeek();

            range.Start = range.Start.AddDays(-7).Date;
            range.End = range.End.AddDays(-7).Date;

            return range;
        }

        /// <summary>
        /// Thises the week.
        /// </summary>
        /// <returns></returns>
        public static DateRange ThisWeek()
        {
            DateTime date = Now;

            DateRange range = new DateRange();

            range.Start = date.Date.AddDays(-(int)date.DayOfWeek).Date;
            range.End = range.Start.AddDays(7).AddSeconds(-1).Date;

            return range;
        }

        /// <summary>
        /// Gets the current hour time.
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentHourTime()
        {
            string value = DateTime.Now.ToString("HHmm");

            return value;
        }

        #endregion Public Fuinctionalities
    }
}
