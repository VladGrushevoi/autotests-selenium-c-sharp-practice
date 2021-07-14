using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

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
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://www.linkedin.com");
        }

        [Test]
        public void TestAuthorization()
        {
            var emailElementInput = magic.FindElement(_driver, "//input[@name='session_key']");
            var passElementInput = magic.FindElement(_driver, "//input[@name='session_password']");

            magic.SendKeysToElement(emailElementInput, $"{Environment.GetEnvironmentVariable("LINKEDIN__EMAIL")}");
            magic.SendKeysToElement(passElementInput, $"{Environment.GetEnvironmentVariable("LINKEDIN__PASS")}");
            Thread.Sleep(5000);
            magic.FindElementAndClick(_driver, "//button[@data-tracking-control-name='homepage-basic_signin-form_submit-button']");
            Thread.Sleep(1000);
            magic.FindElementAndClick(_driver, "//div[@class='profile-rail-card__actor-link t-16 t-black t-bold']");
            Thread.Sleep(3000);
            var actualTextFromElement = magic.GetValueFromElement(_driver, "//h1[@class='text-heading-xlarge inline t-24 v-align-middle break-words']");
            Assert.AreEqual("Vladyslav Hrushovyi", actualTextFromElement, "Something wrong, not valid username");
        }

        [TearDown]
        public void FinishTests()
        {
            _driver.Quit();
        }
    }
}