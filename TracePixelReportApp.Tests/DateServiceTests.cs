using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TracePixelReportApp.Services;
using Xunit;

namespace TracePixelReportApp.Tests
{
    public class DateServiceTests
    {
        [Fact]
        public void VerifyDates_Should_Return_Date_Tuple()
        {
            // arrange
            var expectedResults = (DateFormatUtil.FormatToUTC("2020-03-01 10:00:00"), DateFormatUtil.FormatToUTC("2020-03-03 09:00:00"), true);
            var sut = new DatesService();
            var userInputDates = "2020-03-01 10:00:00,2020-03-03 09:00:00";

            // act
            var result = sut.VerifyDates(userInputDates);
            // assert
            Assert.Equal(expectedResults, result);
        }
        [Fact]
        public void VerifyDates_Should_Return_Date_Tuple_With_False()
        {
            // arrange
            var expectedResults = (DateFormatUtil.FormatToUTC("2020-03-03 10:00:00"), DateFormatUtil.FormatToUTC("2020-03-01 09:00:00"), false);
            var sut = new DatesService();
            var userInputDates = "2020-03-03 10:00:00,2020-03-01 09:00:00";

            // act
            var result = sut.VerifyDates(userInputDates);

            // assert
            Assert.Equal(expectedResults.Item3, result.datesAreValid);
        }
        [Fact]
        public void VerifyDates_Should_Return_Date_Tuple_With_DateTimeMinValue_And_False()
        {
            // arrange
            var expectedResults = (DateTime.MinValue, DateTime.MinValue, false);
            var sut = new DatesService();
            var userInputDates = "";

            // act
            var result = sut.VerifyDates(userInputDates);

            // assert
            Assert.Equal(expectedResults.Item3, result.datesAreValid);
            Assert.Equal(expectedResults.Item1, result.startDate);
            Assert.Equal(expectedResults.Item2, result.endDate);
        }
        [Fact]
        public void ValidateString_Should_Return_True()
        {
            // arrange
            var sut = new DatesService();
            var userInputDates = "2020-03-03 10:00:00,2020-03-01 09:00:00";

            // act
            var result = sut.ValidateDatesString(userInputDates);

            // assert
            Assert.Equal(true, result);
        }
        [Fact]
        public void ValidateString_Should_Return_False()
        {
            // arrange
            var sut = new DatesService();
            var userInputDates = "asdf";

            // act
            var result = sut.ValidateDatesString(userInputDates);

            // assert
            Assert.Equal(false, result);
        }

        [Fact]
        public void ParseDates_Should_Return_Parsed_DateTimeTuple()
        {
            // arrange
            var sut = new DatesService();
            var userInputDates = "2023-03-03 10:00:00,2020-03-01 09:00:00";
            var expectedResults = (DateFormatUtil.FormatToUTC("2023-03-03 10:00:00"), DateFormatUtil.FormatToUTC("2020-03-01 09:00:00"), true);
            // act
            var result = sut.ParseDates(userInputDates);

            // assert
            Assert.Equal(result, expectedResults);
        }

        [Fact]
        public void ParseDates_Should_Return_Parsed_DateTimeTuple_With_False()
        {
            // arrange
            var sut = new DatesService();
            var userInputDates = "2020-03-73 10:00:00,2020-03-01 89:00:00";
            var expectedResults = (DateTime.MinValue, DateTime.MinValue, false);
            // act
            var result = sut.ParseDates(userInputDates);

            // assert
            Assert.Equal(result, expectedResults);
        }

        [Fact]
        public void CheckOrderOfDates_Should_Return_Parsed_DateTimeTuple_With_True()
        {
            // arrange
            var sut = new DatesService();
            var userInputDates = (DateFormatUtil.FormatToUTC("2019-03-03 10:00:00"), DateFormatUtil.FormatToUTC("2020-03-01 09:00:00"), false);
            var expectedResults = (DateFormatUtil.FormatToUTC("2019-03-03 10:00:00"), DateFormatUtil.FormatToUTC("2020-03-01 09:00:00"), true);
            // act
            var result = sut.CheckOrderOfDates(userInputDates);

            // assert
            Assert.Equal(result, expectedResults);
        }

        [Fact]
        public void CheckOrderOfDates_Should_Return_Parsed_DateTimeTuple_With_False()
        {
            // arrange
            var sut = new DatesService();
            var userInputDates = (DateFormatUtil.FormatToUTC("2032-03-03 10:00:00"), DateFormatUtil.FormatToUTC("2020-03-01 09:00:00"), false);
            var expectedResults = (DateFormatUtil.FormatToUTC("2032-03-03 10:00:00"), DateFormatUtil.FormatToUTC("2020-03-01 09:00:00"), false);
            // act
            var result = sut.CheckOrderOfDates(userInputDates);

            // assert
            Assert.Equal(result, expectedResults);
        }
    }
}
