using System;
using System.IO;

namespace Utils
{
    public class ManageEnvVariables
    {
        public static void InitEnvarinmentVariables()
        {
            if (!File.Exists(@"D:\test-c-sharp\nunit-selenium\.env"))
            {
                System.Console.WriteLine("true");
                return;
            }

            foreach (var line in File.ReadAllLines(@"D:\test-c-sharp\nunit-selenium\.env"))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
    }
}