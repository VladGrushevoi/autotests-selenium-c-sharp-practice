using OpenQA.Selenium;
using Utils;

namespace Spotify
{
    public class ProfileUserPageObject
    {
        private IWebDriver _driver;

        private readonly By userNameText = By.XPath( "//h1[@class='a12b67e576d73f97c44f1f37026223c4-scss']");

        public ProfileUserPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetUserNameText()
        {
            WaiterElement.WaitElement(_driver, userNameText);
            return _driver.FindElement(userNameText).Text;
        }
    }
}