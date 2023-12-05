using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject.PageObject.ChangeSettings
{
    class ProfilePage
    {
        private IWebDriver driver;

        private By descriptionField = By.XPath("//*[@id='update-description']");
        private By saveButton = By.XPath("//*[@id='edit-controls']/div/div/button[1]");

        public ProfilePage(IWebDriver browser)
        {
            driver = browser;
        }

        public void FillDescription(ProfileBO profileData)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

                Console.WriteLine("Esperando a que aparezca el campo de descripción.");
                IWebElement txtDescription = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(descriptionField));

                Console.WriteLine("Llenando el campo de descripción.");
                txtDescription.Clear();
                txtDescription.SendKeys(profileData.DescriptionText);

                Console.WriteLine("Guardando la descripción.");
                IWebElement btnSave = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(saveButton));
                btnSave.Click();

                Console.WriteLine("Descripción guardada correctamente.");
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

