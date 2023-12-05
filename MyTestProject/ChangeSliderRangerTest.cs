using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;

using MyTestProject.Reports;

namespace MyTestProject
{
    [TestClass]
    public class ChangeSliderRangerTest
    {

        private IWebDriver driver;
        private LoginPage loginPage;
        private HomePage homePage;
        private MyStoriesPage storiesNotes;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.wattpad.com/");
            loginPage = new LoginPage(driver);
            homePage = new HomePage(driver);
            storiesNotes = new MyStoriesPage(driver);
            loginPage.GoToLogin();
            loginPage.ClickSegundoBoton();
            loginPage.LoginApplication("bellacoantidema@gmail.com", "Selenium2004-");

        }

        [TestMethod]
        public void ChangeSliderRange()
        {
            homePage.NavigateToMyStoriesPage();
            storiesNotes.NavigateToStoryNotes();
        }
    }
}
