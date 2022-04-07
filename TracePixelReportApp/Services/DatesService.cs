using System.Globalization;
using System.Runtime.CompilerServices;
using TracePixelReportApp.GUIIOHandlers;

[assembly: InternalsVisibleTo("TracePixelReportApp.Tests")]
namespace TracePixelReportApp.Services
{
    public class DatesService
    {
        private readonly IUserInformerHandler _userInformerHandler = new UserInformerHandler();
        public DatesService(IUserInformerHandler userInformerHandler)
        {
            _userInformerHandler = userInformerHandler;
        }

        public DatesService()
        {
        }

        public (DateTime startDate, DateTime endDate, bool datesAreValid) VerifyDates(string userInputDates)
        {
            if (!ValidateDatesString(userInputDates))
            return (DateTime.MinValue, DateTime.MinValue, false);

            var dateTuple = ParseDates(userInputDates);

            if (dateTuple.parsed)
                dateTuple = CheckOrderOfDates(dateTuple);
            
        return dateTuple;
        }

        internal bool ValidateDatesString(string userInputdates)
        {
            if (string.IsNullOrEmpty(userInputdates) || !userInputdates.Contains(',')|| !userInputdates.Any(char.IsDigit)|| userInputdates.Any(char.IsLetter) || !userInputdates.Contains('-') || !userInputdates.Contains(':'))
            {
                _userInformerHandler.DatesWrongFormat();
                return false;
            }
            return true;
        }

        internal (DateTime startDate, DateTime endDate, bool parsed) ParseDates(string userInputDates)
        {
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;
            string[] splitDates = userInputDates.Split(',');

            bool startDateOk = DateTime.TryParse(splitDates[0], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out startDate);
            bool endDateOk = DateTime.TryParse(splitDates[1], CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out endDate);

            if (startDateOk && endDateOk)
            {
                return (startDate, endDate, true);
            }
            else
            {
                _userInformerHandler.DatesWrongOrder();
                return (startDate, endDate, false);
            }
        }

        internal (DateTime startDate, DateTime endDate, bool dateOrder) CheckOrderOfDates((DateTime startDate, DateTime endDate, bool parsed) dateTuple)
        {
            if (dateTuple.startDate <= dateTuple.endDate)
            {
                return (dateTuple.startDate, dateTuple.endDate, true);
            }
            else
            {
                return (dateTuple.startDate, dateTuple.endDate, false);
            }
        }
    }
}
