using System.Threading;
using OpenQA.Selenium;
using Utils;

namespace Spotify
{
    public class UserMainSpotifyPageObject
    {
        private IWebDriver _driver;

        private readonly By profileButton = By.XPath("//button[@data-testid='user-widget-link']");
        private readonly By profileClick = By.XPath("//span[text()='Профиль']");

        public UserMainSpotifyPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public ProfileUserPageObject ClickOnUserProfile()
        {
            WaiterElement.WaitElement(_driver, profileButton);
            _driver.FindElement(profileButton).Click();

            WaiterElement.WaitElement(_driver, profileClick);
            _driver.FindElement(profileClick).Click();

            return new ProfileUserPageObject(_driver);
        }
    }
}