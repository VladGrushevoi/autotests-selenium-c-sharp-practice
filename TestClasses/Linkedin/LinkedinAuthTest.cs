using System;
using Linkedin;
using NUnit.Framework;

namespace TestLinkedin
{
    [TestFixture]
    public class LinkedinAuthTest : BaseTestLinkedin
    {
        [Test]
        public void TestAuthorizationLinkedin()
        {
            _webDriver.Navigate().GoToUrl("https://www.linkedin.com");

            var linkedinAuth = new LoginPageObject(_webDriver)
                                .EnterLoginInfo($"{Environment.GetEnvironmentVariable("EMAIL")}", $"{Environment.GetEnvironmentVariable("PASS")}")
                                .ClickOnProfilePage();
                                
            var actualTextFromElement = linkedinAuth.GetUserNameOnProfilePage();
            Assert.AreEqual("Vladyslav Hrushovyi", actualTextFromElement, "Something wrong, not valid username");
        }
    }
}