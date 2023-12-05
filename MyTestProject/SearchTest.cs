using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using MyTestProject.Reports;

using MyTestProject.PageObject.ChangeSettings;
using MyTestProject.Common;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using MyTestProject.Handler;
using TestContext = NUnit.Framework.TestContext;

namespace MyTestProject
{
    [TestClass]
    public class SearchTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        protected Browser Browser { get; private set; }

        [TestInitialize]
        public void Setup()
        {
            ExtentReporting.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.MethodName);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            loginPage.GoToLogin();
            loginPage.ClickSegundoBoton();
            loginPage.LoginApplication("bellacoantidema@gmail.com", "Selenium2004-");

            Browser = new Browser(driver);
        }

        [TestMethod]
        public void TestSearch()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Passed)
            {
                homePage.PerformSearch("Esposados");
                ScreenShotHandler.TakeScreenshot(driver);
            }

            if (driver != null)
            {
                EndTest();
                ExtentReporting.EndReporting();
                driver.Quit();
            }

        }

        private void EndTest()
        {
            var testStatus = NUnit.Framework.TestContext.CurrentContext.Result.Outcome.Status;
            var message = NUnit.Framework.TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Skipped:
                    ExtentReporting.LogFail($"Test se ha salteado {message}");
                    break;
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test ha fallado {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogScreenshot("Finalizando test", Browser.GetScreenshot());
        }
    }
}