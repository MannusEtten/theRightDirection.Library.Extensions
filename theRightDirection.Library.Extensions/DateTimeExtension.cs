using System;

namespace theRightDirection.Library.Extensions
{
    public static class DateTimeExtension
    {
        public static double TimeStampInMilliseconds(this DateTime dateTime)
        {
            DateTime utcTime = dateTime.ToUniversalTime();
            TimeSpan t = (utcTime - new DateTime(1970, 1, 1));
            return t.TotalMilliseconds;
        }

        public static DateTime TimeStampAsDateTime(this DateTime dateTime, double unixTimeStamp)
        {
            DateTime converted = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            DateTime newDateTime = converted.AddMilliseconds(unixTimeStamp);
            return newDateTime;
        }
    }
}