using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Configuration;
using MyTestProject.PageObject.ChangeSettings;

using MyTestProject.Common;
using MyTestProject.Reports;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyTestProject
{
    [TestClass]
    public class ChangeProfileTest
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private ProfilePage profilePage;

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
            profilePage = new ProfilePage(driver);
            loginPage.GoToLogin();
            loginPage.ClickSegundoBoton();
            loginPage.LoginApplication("bellacoantidema@gmail.com", "Selenium2004-");

            Browser = new Browser(driver);
        }

        [TestMethod]
        public void ChangeProfile()
        {
            homePage.NavigateToProfilePage();
            profilePage.FillDescription(new ProfileBO());
        }

        [TearDown]
        public void Cleanup()
        {
            EndTest();
            ExtentReporting.EndReporting();
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