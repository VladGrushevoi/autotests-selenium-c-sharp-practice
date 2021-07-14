using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace nunit_selenium
{
    public class LinkedInAuthorizationTests
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

            var emailElementInput = magic.FindElement(_driver, "//input[@name='session_key']");
            var passElementInput = magic.FindElement(_driver, "//input[@name='session_password']");

            magic.SendKeysToElement(emailElementInput, $"{Environment.GetEnvironmentVariable("EMAIL")}");
            magic.SendKeysToElement(passElementInput, $"{Environment.GetEnvironmentVariable("PASS")}");
            magic.FindElementAndClick(_driver, "//button[@data-tracking-control-name='homepage-basic_signin-form_submit-button']");
            Thread.Sleep(1000);
            magic.FindElementAndClick(_driver, "//div[@class='profile-rail-card__actor-link t-16 t-black t-bold']");
            Thread.Sleep(3000);
            var actualTextFromElement = magic.GetTextFromElement(_driver, "//h1[@class='text-heading-xlarge inline t-24 v-align-middle break-words']");
            Assert.AreEqual("Vladyslav Hrushovyi", actualTextFromElement, "Something wrong, not valid username");
        }

        [Test]
        public void TestAuthorizationSpotify()
        {
            _driver.Navigate().GoToUrl("https://open.spotify.com/");
            magic.FindElementAndClick(_driver, "//button[@data-testid='login-button']");

            Thread.Sleep(1500);    
            var emailElementInput = magic.FindElement(_driver, "//input[@name='username']");
            var passElementInput = magic.FindElement(_driver, "//input[@name='password']");

            magic.SendKeysToElement(emailElementInput, $"{Environment.GetEnvironmentVariable("EMAIL")}");
            magic.SendKeysToElement(passElementInput, $"{Environment.GetEnvironmentVariable("PASS")}");

            magic.FindElementAndClick(_driver, "//button[@id='login-button']");
            Thread.Sleep(1500);
            magic.FindElementAndClick(_driver, "//button[@data-testid='user-widget-link']");
            magic.FindElementAndClick(_driver, "//span[text()='Профиль']");
            Thread.Sleep(1500);
            string actualTextFromElement =  magic.GetTextFromElement(_driver, "//h1[@class='a12b67e576d73f97c44f1f37026223c4-scss']");

            Assert.AreEqual("Grushik", actualTextFromElement, "Username does not");
        }

        [TearDown]
        public void FinishTests()
        {
            _driver.Quit();
        }
    }
}