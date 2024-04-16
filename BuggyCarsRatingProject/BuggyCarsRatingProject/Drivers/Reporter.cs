using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;

namespace BuggyCarsRatingProject.Drivers
{
    public class Reporter : Hook
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        private static ExtentReports StartReporting()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"..\..\..\..\Result\";

            if (extentReports == null)
            {
                Directory.CreateDirectory(path);

                extentReports = new ExtentReports();
                var htmlReporter = new ExtentHtmlReporter(path);

                extentReports.AttachReporter(htmlReporter);
            }
            return extentReports;
        }

        public static void ReportingCreateTest(string testName)
        {
            extentTest = StartReporting().CreateTest(testName);
        }

        public static void ReportingEndRepoting()
        {
            StartReporting().Flush();
        }

        public static void ReportingLogPass(string testName)
        {
            extentTest.Pass(testName);
        }

        public static void ReportingLogFail(string testName)
        {
            extentTest.Fail(testName);
        }

        public static void ReportingLogInfo(string testName)
        {
            extentTest.Info(testName);
        }

        public static void ReportingLogScreenShot(string info, string image)
        {
            extentTest.Info(info, MediaEntityBuilder.CreateScreenCaptureFromBase64String(image).Build());
        }

    }
}