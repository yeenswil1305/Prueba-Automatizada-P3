using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace MyTestProject.Reports

{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;

        private static ExtentTest extentTest;


        private static ExtentReports startReporting()
        {
            var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(assemblyLocation, "resultados");

            if (!Directory.Exists(path))
            {
                try
                {
                    Directory.CreateDirectory(path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating directory: {ex.Message}");

                }
            }

            if (extentReports == null)
            {
                extentReports = new ExtentReports();

                var htmlReporter = new ExtentSparkReporter(Path.Combine(path, "reporte.html"));

                extentReports.AttachReporter(htmlReporter);
            }

            return extentReports;
        }

        public static void CreateTest(string TestName)
        {
            extentTest = startReporting().CreateTest(TestName);
        }

        public static void EndReporting()
        {
            startReporting().Flush();
        }

        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }


        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }

        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }

        public static void LogScreenshot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }
    }
}
