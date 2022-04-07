using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("TracePixelReportApp.Tests")]
namespace TracePixelReportApp.GUIIOHandlers
{
    public class DateInputHandler
    {
        private readonly IUserInformerHandler _userInformerHandler = new UserInformerHandler();
        public DateInputHandler(IUserInformerHandler userInformerHandler)
        {
            _userInformerHandler = userInformerHandler;
        }
        public DateInputHandler()
        {

        }
        public string RecieveDateInput(DateTime logStartDate, DateTime logEndDate)
        {
                _userInformerHandler.AskForDates(logStartDate, logEndDate);
                var datesIn = Console.ReadLine();
               
            return datesIn;
        }
    }
}
