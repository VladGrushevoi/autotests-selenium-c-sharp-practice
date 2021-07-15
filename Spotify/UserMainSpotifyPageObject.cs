using System.Threading;
using OpenQA.Selenium;

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
            _driver.FindElement(profileButton).Click();
            Thread.Sleep(1500);

            _driver.FindElement(profileClick).Click();
            Thread.Sleep(1500);

            return new ProfileUserPageObject(_driver);
        }
    }
}