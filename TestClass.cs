using System;
using System.Threading;
using Linkedin;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Spotify;

namespace nunit_selenium
{
    public class TestClass
    {
        private IWebDriver _driver;
        private MagicClass magic;


        [SetUp]
        public void Setup()
        {
            magic = new MagicClass();
            magic.LoadEnvVariables();
            _driver = new ChromeDriver(@"C:\bin\");
            _driver.Manage().Window.Maximize();
        }

        [Test]
        public void TestAuthorizationLinkedin()
        {
            _driver.Navigate().GoToUrl("https://www.linkedin.com");

            var linkedinAuth = new LoginPageObject(_driver)
                                .EnterLoginInfo($"{Environment.GetEnvironmentVariable("EMAIL")}", $"{Environment.GetEnvironmentVariable("PASS")}")
                                .ClickOnProfilePage();
                                
            var actualTextFromElement = linkedinAuth.GetUserNameOnProfilePage();
            Assert.AreEqual("Vladyslav Hrushovyi", actualTextFromElement, "Something wrong, not valid username");
        }

        [Test]
        public void TestAuthorizationSpotify()
        {
            _driver.Navigate().GoToUrl("https://open.spotify.com/");
            var spotifyAuth = new MainSpotifyPageObject(_driver)
                                .SpotifyLoginButton()
                                .Login($"{Environment.GetEnvironmentVariable("EMAIL")}", $"{Environment.GetEnvironmentVariable("PASS")}")
                                .ClickOnUserProfile();
            
            string actualTextFromElement =  spotifyAuth.GetUserNameText();

            Assert.AreEqual("Grushik", actualTextFromElement, "Username does not");
        }

        [TearDown]
        public void FinishTests()
        {
            _driver.Quit();
        }
    }
}