using System;
using System.Threading;
using OpenQA.Selenium;
using Utils;

namespace Spotify
{
    public class MainSpotifyPageObject
    {
        private IWebDriver _driver;

        private readonly By loginButton = By.XPath("//button[@data-testid='login-button']");

        public MainSpotifyPageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public MainLoginSpotifyPageObject SpotifyLoginButton()
        {
            WaiterElement.WaitElement(_driver, loginButton);
           _driver.FindElement(loginButton).Click();
           
           return new MainLoginSpotifyPageObject(_driver); 
        }
    }
}