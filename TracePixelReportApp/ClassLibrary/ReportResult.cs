
    public class ReportResult
    {
        public string Url { get; set; }
        public int NumberOfUniqueVisitors { get; set; }
        public int NumberOfPageViews { get; set; }

        public ReportResult(string url, int numberOfUniqueVisitors, int numberOfPageViews)
        {
            Url = url;
            NumberOfUniqueVisitors = numberOfUniqueVisitors;
            NumberOfPageViews = numberOfPageViews;
        }
}

