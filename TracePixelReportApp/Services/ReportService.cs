using TracePixelReportApp.ClassLibrary;

namespace TracePixelReportApp.Services
{
    public static class ReportService
    {
        public static List<ReportResult> GenerateReport(List<LogRow> listLog)
        {
            List<ReportResult> report = new List<ReportResult>();
            foreach (var urls in listLog.GroupBy(x => x.Url))
            {
                var result = new ReportResult(urls.Key, urls.Count(), urls.Select(x => x.UserId).Distinct().Count());
                report.Add(result);
            }
            return report; ;
        }
    }
}
