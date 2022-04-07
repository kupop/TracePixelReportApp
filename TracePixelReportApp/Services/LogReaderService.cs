
namespace TracePixelReportApp.Services
{
    public static class LogReaderService
    {
        public static List<string> ReadTextLog(string inputPath)
        {
            try
            {
                var stringLogList = new List<string>();
                var logFile = File.ReadAllLines(inputPath);
                foreach (var row in logFile) stringLogList.Add(row);
                stringLogList.Remove(stringLogList[0]);

                return stringLogList;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press any key to quit.");
                Console.ReadLine();
                Environment.Exit(0);
                return new List<string>();
            }
        }
    }
}

