using System.Collections.Generic;
using System.Linq;
using TracePixelReportApp.ClassLibrary;
using TracePixelReportApp.Services;
using Xunit;

namespace TracePixelReportApp.Tests
{
    public class SortLogServiceTests
    {
        [Fact]
        public void SortLogOnInputDates_Should_Return_Sorted_List()
        {
            // arrange
            var sut = new SortLogService();
            List<LogRow> log = GetMockLog();
            var userInputDates = (DateFormatUtil.FormatToUTC("2020-03-01 10:00:00"), DateFormatUtil.FormatToUTC("2020-03-03 09:00:00"), true);
            var earliestLogDate = log.OrderBy(a => a.TimeStamp).First().TimeStamp;
            var latestLogDate = log.OrderBy(a => a.TimeStamp).Last().TimeStamp;

            var expectedObjectsInResult = 1;

            // act
            var result = sut.SortLogOnInputDates(log, userInputDates, earliestLogDate, latestLogDate);

            // assert
            Assert.Equal(expectedObjectsInResult, result.Count);
            Assert.IsType<List<LogRow>>(result);
        }
        [Fact]
        public void SortLogOnInputDates_Should_Return_Two_ListObject()
        {
            // arrange
            List<LogRow> log = GetMockLog();
            var sut = new SortLogService();
            var userInputDates = (DateFormatUtil.FormatToUTC("2020-03-01 08:59:59"), DateFormatUtil.FormatToUTC("2020-03-03 10:50:21"), true);
            var earliestLogDate = log.OrderBy(a => a.TimeStamp).First().TimeStamp;
            var latestLogDate = log.OrderBy(a => a.TimeStamp).Last().TimeStamp;

            var expectedObjectsInResult = 2;

            // act
            var result = sut.SortLogOnInputDates(log, userInputDates, earliestLogDate, latestLogDate);

            // assert
            Assert.Equal(expectedObjectsInResult, result.Count);
        }

        internal List<LogRow> GetMockLog()
        {
            List<LogRow> log = new List<LogRow>
            {
                new LogRow(DateFormatUtil.FormatToUTC("2020-03-01 09:00:00"), "cat.html", "ddr"),
                new LogRow(DateFormatUtil.FormatToUTC("2020-03-02 09:20:10"), "dog.html", "ddr"),
                new LogRow(DateFormatUtil.FormatToUTC("2020-03-03 10:50:22"), "dog.html", "bbc"),
            };

            return log;
        }
    }
}