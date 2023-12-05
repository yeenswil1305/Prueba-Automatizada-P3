using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTestProject.Common;
using MyTestProject.Handler;
using MyTestProject.Reports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TestContext = NUnit.Framework.TestContext;

namespace MyTestProject
{
    [TestFixture]
    public class LoginTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        protected Browser Browser {  get; private set; }

        [SetUp]
        public void Setup()
        {
            ExtentReporting.CreateTest(NUnit.Framework.TestContext.CurrentContext.Test.MethodName);
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);

            Browser = new Browser(driver);
        }

        [Test]
        public void Login()
        {
            loginPage.GoToLogin();
            loginPage.ClickSegundoBoton();
            loginPage.LoginApplication("bellacoantidema@gmail.com", "Selenium2004-");
        }

        [TearDown]
        public void Cleanup()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == TestStatus.Passed)
            {

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

            ExtentReporting.LogScreenshot("Finalizando test",Browser.GetScreenshot());
        }
    }
}
