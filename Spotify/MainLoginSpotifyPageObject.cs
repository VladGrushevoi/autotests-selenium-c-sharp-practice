using System.Threading;
using OpenQA.Selenium;
using Utils;

namespace Spotify
{
    public class MainLoginSpotifyPageObject
    {
        private IWebDriver _driver;

        private readonly By emailInputButton = By.XPath("//input[@name='username']");
        private readonly By passInputButton = By.XPath("//input[@name='password']");
        private readonly By loginButton = By.XPath("//button[@id='login-button']");


        public MainLoginSpotifyPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public UserMainSpotifyPageObject Login(string email, string pass)
        {
            WaiterElement.WaitElement(_driver, emailInputButton);
            WaiterElement.WaitElement(_driver, loginButton);
            
            _driver.FindElement(emailInputButton).SendKeys(email);
            _driver.FindElement(passInputButton).SendKeys(pass);
            _driver.FindElement(loginButton).Click();

            return new UserMainSpotifyPageObject(_driver);
        }
    }
}