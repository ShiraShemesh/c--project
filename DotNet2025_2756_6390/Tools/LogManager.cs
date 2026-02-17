using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class LogManager
    {
        private static string BaseDirPath = @"Log";
        public static string getPathDir()
        {
            return $@"{BaseDirPath}\{DateTime.Now.Month:MM}";
        }
        public static string getPathFile()
        {
            String fileName = $@"Log_{DateTime.Now:dd-MM-yyyy}.txt";
            return $@"{BaseDirPath}\{DateTime.Now.Month:MM}\{fileName}";
        }
        public static void writeToLog(string projectName, string funcName, string message)
        {
            string path = ($@"{BaseDirPath}\{getPathDir()}");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            string pathFile = ($@"{BaseDirPath}\{getPathDir()}\{getPathFile()}");
            if (!File.Exists(pathFile))
                File.Create(pathFile).Close();
            using (StreamWriter writer = new StreamWriter(pathFile, true))
            {
                writer.WriteLine($"{DateTime.Now}\t{projectName} : {funcName} \t {message}");
            }
        }
        public static void deleteOldLogs()
        {
            try
            {
                if (!Directory.Exists(BaseDirPath))
                    return;

                var directories = Directory.GetDirectories(BaseDirPath);
                DateTime threshold = DateTime.Now.AddMonths(-2);

                foreach (var dir in directories)
                {
                    try
                    {
                        DateTime creation = Directory.GetCreationTime(dir);
                        if (creation < threshold)
                        {
                            Directory.Delete(dir, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Failed to delete log directory '{dir}': {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete old logs: {ex.Message}");
            }
        }

    }
}
