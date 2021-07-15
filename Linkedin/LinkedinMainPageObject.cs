using System.Threading;
using OpenQA.Selenium;

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
            _driver.FindElement(profileButton).Click();
            Thread.Sleep(500);

            return new ProfileLinkedinPageObject(_driver);
        }
    }
}