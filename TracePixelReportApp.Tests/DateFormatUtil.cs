using System;
using System.Globalization;

namespace TracePixelReportApp.Tests
{
    public static class DateFormatUtil
    {
        public static DateTime FormatToUTC(string date)
        {
            return DateTime.Parse(date, CultureInfo.InvariantCulture);
        }
    }
}