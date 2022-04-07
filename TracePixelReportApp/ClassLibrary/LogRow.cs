namespace TracePixelReportApp.ClassLibrary
{
    public class LogRow
    {
        public DateTime TimeStamp { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }


        public LogRow(DateTime timeStamp, string url, string userId)
        {
            TimeStamp = timeStamp;
            Url = url;
            UserId = userId;
        }
    }
}

