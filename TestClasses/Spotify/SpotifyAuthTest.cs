using System;
using NUnit.Framework;
using Spotify;

namespace TestSpotify
{
    [TestFixture]
    public class SpotifyAuthTest : BaseTestSpotify
    {
        [Test]
        public void TestAuthorizationSpotify()
        {
            _webDriver.Navigate().GoToUrl("https://open.spotify.com/");
            var spotifyAuth = new MainSpotifyPageObject(_webDriver)
                                .SpotifyLoginButton()
                                .Login($"{Environment.GetEnvironmentVariable("EMAIL")}", $"{Environment.GetEnvironmentVariable("PASS")}")
                                .ClickOnUserProfile();
            
            string actualTextFromElement =  spotifyAuth.GetUserNameText();

            Assert.AreEqual("Grushik", actualTextFromElement, "Username does not");
        }
    }    
}