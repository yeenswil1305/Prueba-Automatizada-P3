using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace MyTestProject
{
    class MyStoriesPage
    {
        private IWebDriver driver;

        public MyStoriesPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By myStory = By.XPath("//*[@id='creation-works-listing']/div[1]/div/div[1]/div[1]/section/div/div/div/div[1]/div[2]/div[2]/h3/a/strong");
        private By storyNotes = By.XPath("//*[@id='story-planner-tab']/div");


        public void NavigateToStoryNotes()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

                IWebElement btnMyStory = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(myStory));
                btnMyStory.Click();

                IWebElement btnStoryNotes = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(storyNotes));
                btnStoryNotes.Click();


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
    }
}
