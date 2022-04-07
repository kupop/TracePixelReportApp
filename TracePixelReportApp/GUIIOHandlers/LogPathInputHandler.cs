namespace TracePixelReportApp.GUIIOHandlers
{
    public static class LogPathInputHandler
    {
        public static string GetPathToLogFile()
        {
            bool pathIsValid = false;
            string logpath = "default value";

            while (!pathIsValid)
            {
                Console.WriteLine(@"Give the full path to the log file as exemplified: C:\Users\Leili\Desktop\log.txt");
                logpath = $@"{Console.ReadLine()}";

                pathIsValid = ValidatePath(logpath);
            }

            return logpath;
        }

        static bool ValidatePath(string logpath)
        {
            if (!File.Exists(logpath))
            {
                Console.WriteLine("File does not exist. Please specify path to logfile.\n");
                return false;
            }
            if (Path.GetExtension(logpath) != ".txt")
            {
                Console.WriteLine("File must end with .txt. Please specify full path to logfile.\n");
                return false;
            }
            return true;
        }
    }
}