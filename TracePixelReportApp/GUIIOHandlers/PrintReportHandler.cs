namespace TracePixelReportApp.GUIIOHandlers
{
    public static class PrintReportHandler
    {
        public static void PrintReport(List<ReportResult> report)
        {
            var longestUrl = report.Max(r => r.Url.Length);
            var urlString = "url";
            Console.WriteLine($"|{urlString.PadRight(longestUrl)}|page views  |visitors|");
            foreach (var row in report)
            {
                Console.WriteLine($"|{row.Url.PadRight(longestUrl)}|{row.NumberOfPageViews.ToString().PadRight(11)}|{row.NumberOfUniqueVisitors.ToString().PadRight(7)}|");
            }
        }
    }
}
