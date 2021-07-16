using System.Threading;
using OpenQA.Selenium;
using Utils;

namespace Linkedin
{
    public class LinkedinMainPageObject
    {
        private IWebDriver _driver;

        private readonly By profileButton = By.XPath("//div[@class='profile-rail-card__actor-link t-16 t-black t-bold']");

        public LinkedinMainPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public ProfileLinkedinPageObject ClickOnProfilePage()
        {
            //WaiterElement.WaitElement(_driver, profileButton);
            _driver.FindElement(profileButton).Click();

            return new ProfileLinkedinPageObject(_driver);
        }
    }
}