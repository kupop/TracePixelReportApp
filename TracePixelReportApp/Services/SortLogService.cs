using TracePixelReportApp.ClassLibrary;
using TracePixelReportApp.GUIIOHandlers;

namespace TracePixelReportApp.Services
{
    public class SortLogService
    {
        private readonly IUserInformerHandler _userInformerHandler = new UserInformerHandler();
        public SortLogService(IUserInformerHandler userInformerHandler)
        {
            _userInformerHandler = userInformerHandler;
        }
        public SortLogService()
        {

        }

        public List<LogRow> SortLogOnInputDates(List<LogRow> listLog, (DateTime startDate, DateTime endDate, bool) dates, DateTime earliestLogDate, DateTime latestLogDate)
        {

            listLog = listLog.Where(s => s.TimeStamp >= dates.startDate && s.TimeStamp <= dates.endDate).ToList();

            if (!listLog.Any())
            {
                _userInformerHandler.NoLogEntriesFound();
                Environment.Exit(0);
            }
            return listLog;
        }
    }
}
