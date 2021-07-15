using System;
using System.Threading;
using OpenQA.Selenium;

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
           _driver.FindElement(loginButton).Click();
           Thread.Sleep(1500);
           
           return new MainLoginSpotifyPageObject(_driver); 
        }
    }
}