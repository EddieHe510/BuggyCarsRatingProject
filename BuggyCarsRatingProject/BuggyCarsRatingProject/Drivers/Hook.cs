using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace BuggyCarsRatingProject.Drivers
{
    [TestFixture]
    public class Hook
    {
        public static IWebDriver driver;
        protected Browser browser;

        [BeforeScenario]
        public void StartWebsite()
        {
            Reporter.ReportingCreateTest(TestContext.CurrentContext.Test.MethodName);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://buggy.justtestit.org/");

            browser = new Browser(driver);
        }


        [AfterScenario]
        public void CloseBrowser()
        {
            DriverEndTest();
            Reporter.ReportingEndRepoting();
            driver.Quit();
        }

        [AfterStep]
        public void ScreenShotAfterStep()
        {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();

            string screenshotPath = @"..\..\..\Result\Screenshot\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";

            byte[] screenshotBytes = Convert.FromBase64String(screenshot.AsBase64EncodedString);

            File.WriteAllBytes(screenshotPath, screenshotBytes);
        }



        private void DriverEndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    Reporter.ReportingLogFail($"Test has failed {message}");
                    break;

                case TestStatus.Skipped:
                    Reporter.ReportingLogInfo($"Test skipped {message}");
                    break;

                default:
                    break;
            }

            Reporter.ReportingLogScreenShot("Ending test", browser.BroswerGetScreenShot());
        }
    }
}
