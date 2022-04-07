

namespace TracePixelReportApp.GUIIOHandlers
{
    class UserInformerHandler : IUserInformerHandler
    {
        public void AskForDates(DateTime logStartDate, DateTime logEndDate)
        {
            Console.WriteLine("Type in start-date and end-date to specify time span for report.");
                Console.WriteLine("Separate with a comma (,) and format according to: YYYY-MM-DD HH:MM:SS");
                Console.WriteLine($"The earliest and lates dates in the selected log are: {logStartDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss")} and {logEndDate.ToString("yyyy'-'MM'-'dd' 'HH':'mm':'ss")}.");
        }

        public void DatesWrongFormat()
        {
            Console.WriteLine("The dates you entered seem to be formatted the wrong way.\n");
        }

        public void DatesWrongOrder()
        {
            Console.WriteLine("The dates you entered seem to be in the wrong order. Make sure you write the earlier date first.\n");
        }

        public void NoLogEntriesFound()
        {
            Console.WriteLine("The log has no entries within the specified time span.\n");
        }
    }
}
