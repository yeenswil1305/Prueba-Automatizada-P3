using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MyTestProject
{
    class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver browser)
        {
            driver = browser;
        }

        private By account = By.XPath("//*[@id='profile-dropdown']/button/span[2]");
        private By settings = By.XPath("//*[@class='dropdown-menu dropdown-menu-right large']/ul/li[9]");
        private By write = By.XPath("//*[@id='header']/nav[2]/ul/li/button");
        private By myStories = By.XPath("//*[@id='header']/nav[2]/ul/li/div[2]/ul/li[2]/a");
        private By profile = By.XPath("//*[@id='profile-dropdown']/div[2]/ul/li[1]/a");
        private By searchBox = By.XPath("//*[@id='search-query']");
        private By searchButton = By.XPath("//*[@id='header-item-search']/div/form/button/span");

        public void NavigateToSettingsPage()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement btnAccount = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(account));
                btnAccount.Click();

                IWebElement btnSettings = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(settings));
                btnSettings.Click();

                Console.WriteLine("Navegación a la página de configuración exitosa.");
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

        public void NavigateToMyStoriesPage()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement btnWrite = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(write));
                btnWrite.Click();

                System.Threading.Thread.Sleep(1000);

                IWebElement btnMyStories = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(myStories));
                btnMyStories.Click();

                Console.WriteLine("Navegación a la página de 'My Stories' exitosa.");
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

        public void NavigateToProfilePage()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement btnAccount = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(account));
                btnAccount.Click();

                IWebElement btnProfile = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(profile));
                btnProfile.Click();

                System.Threading.Thread.Sleep(1000);

                By dismissButton = By.XPath("//*[@id='component-walletwithonboarding-profile-%2fuser%2fseleniumbook']/div/div[2]/div/button");
                IWebElement btnDismiss = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(dismissButton));
                btnDismiss.Click();

                System.Threading.Thread.Sleep(1000);

                By editProfileButton = By.XPath("//*[@id='page-navigation']/div[2]/div/div/button/span[2]");
                IWebElement btnEditProfile = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(editProfileButton));
                btnEditProfile.Click();

                Console.WriteLine("Navegación a la página de perfil exitosa.");
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

        public void PerformSearch(string searchTerm)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                // Localizar el campo de búsqueda y escribir el término de búsqueda
                IWebElement txtSearchBox = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchBox));
                txtSearchBox.Clear();
                txtSearchBox.SendKeys(searchTerm);

                // Localizar el botón de búsqueda y hacer clic
                IWebElement btnSearch = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchButton));
                btnSearch.Click();

                Console.WriteLine($"Búsqueda exitosa para: {searchTerm}");
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