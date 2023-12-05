using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyTestProject
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By login = By.CssSelector("button[class='Ngxjj transparent-button']");
        private IWebElement BtnLogin => driver.FindElement(login);

        private By segundoBoton = By.CssSelector("button[class='btn__Qzch5 title-sm primary_btn__M0LSa full_width_btn__brrlr']");
        private IWebElement BtnSegundo => driver.FindElement(segundoBoton);

        private By email = By.Id("login-username");
        private IWebElement Email => driver.FindElement(email);

        private By password = By.Id("password");
        private IWebElement Password => driver.FindElement(password);

        private By loginClick = By.CssSelector("button[class='btn__Qzch5 title-sm primary_btn__M0LSa full_width_btn__brrlr']");
        private IWebElement BtnLoginClick => driver.FindElement(loginClick);

        public void GoToLogin()
        {
            BtnLogin.Click();
        }

        public void ClickSegundoBoton()
        {            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(200));
            wait.Until(ExpectedConditions.ElementIsVisible(segundoBoton));

            BtnSegundo.Click();
        }

        public void LoginApplication(string email, string password)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);
            BtnLoginClick.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
         
        }
    }
}

