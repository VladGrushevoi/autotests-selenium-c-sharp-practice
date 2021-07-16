using OpenQA.Selenium;
using Utils;

namespace Linkedin
{
    public class ProfileLinkedinPageObject
    {
        private IWebDriver _driver;

        private readonly By userNameProfile = By.XPath("//h1[@class='text-heading-xlarge inline t-24 v-align-middle break-words']");

        public ProfileLinkedinPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public string GetUserNameOnProfilePage()
        {
            WaiterElement.WaitElement(_driver, userNameProfile);
            return _driver.FindElement(userNameProfile).Text;
        }
    }
}