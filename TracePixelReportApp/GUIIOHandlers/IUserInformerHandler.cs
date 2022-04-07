

namespace TracePixelReportApp.GUIIOHandlers
{
    public interface IUserInformerHandler
    {
        public void AskForDates(DateTime logFirstDate, DateTime logLastDate);
        public void DatesWrongFormat();
        public void DatesWrongOrder();

        public void NoLogEntriesFound();
    }
}
