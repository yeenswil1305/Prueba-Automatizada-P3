using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject
{
    class SettingsPage
    {
        private IWebDriver driver;

        public SettingsPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By dateOfBirth = By.Id("birthdate");
        private By submit = By.CssSelector("button[class='btn__Qzch5 title-sm primary_btn__M0LSa']");

        public void ChangeSettings(SettingsBO change)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement txtBirthday = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(dateOfBirth));

                txtBirthday.Clear();

                txtBirthday.SendKeys(change.TxtBirthdayMonth);
                txtBirthday.SendKeys(change.TxtBirthDay);
                txtBirthday.SendKeys(change.TxtBirthYear);

                IWebElement btnSubmit = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(submit));
                btnSubmit.Click();

                Console.WriteLine("Cambios en la configuración realizados correctamente.");
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine($"Elemento no encontrado: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }
}

