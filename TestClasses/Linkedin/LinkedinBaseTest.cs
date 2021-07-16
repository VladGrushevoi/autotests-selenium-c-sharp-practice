using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Settings;
using Utils;

namespace TestLinkedin
{
    public class BaseTestLinkedin
    {
        protected IWebDriver _webDriver;

        [OneTimeSetUp]
        protected void DoBeforeAllTheTest()
        {
            _webDriver = new ChromeDriver(@"C:/bin/");
            ManageEnvVariables.InitEnvarinmentVariables();
        }

        [SetUp]
        protected void DoBeforeEach()
        {
            _webDriver.Manage().Cookies.DeleteAllCookies();
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl(LinkedinSettings.LinkedinUrl);
            WaiterElement.ShouldLocate(_webDriver, LinkedinSettings.LinkedinUrl);
        }

        [TearDown]
        protected void DoAfterEach()
        {
            _webDriver.Quit();
        }
    }
}