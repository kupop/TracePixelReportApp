using System.Globalization;
using TracePixelReportApp.ClassLibrary;

namespace TracePixelReportApp.Services
{
    public static class LogMapperService
    {
        public static List<LogRow> MapTextLogToList(List<string> stringLogList)
        {
            var logList = new List<LogRow>();
            foreach (var line in stringLogList)
            {
                string[] splitTextLine = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string date = splitTextLine[0].Replace("UTC", string.Empty).Trim();
                string url = splitTextLine[1].Trim();
                string userId = splitTextLine[2].Trim();
                logList.Add(new LogRow(DateTime.Parse(date, CultureInfo.InvariantCulture), url, userId));
            }

            return logList;
        }
    }
}
