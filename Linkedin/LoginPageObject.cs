using System.Threading;
using OpenQA.Selenium;

namespace Linkedin
{
    public class LoginPageObject
    {
        private IWebDriver _driver;

        private readonly By loginInputButton = By.XPath("//input[@name='session_key']");
        private readonly By passInputButton = By.XPath("//input[@name='session_password']");
        private readonly By loginButton = By.XPath("//button[@data-tracking-control-name='homepage-basic_signin-form_submit-button']");

        public LoginPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public LinkedinMainPageObject EnterLoginInfo(string login, string pass)
        {
            _driver.FindElement(loginInputButton).SendKeys(login);
            _driver.FindElement(passInputButton).SendKeys(pass);
            _driver.FindElement(loginButton).Click();

            Thread.Sleep(500);

            return new LinkedinMainPageObject(_driver);
        }
    }
}