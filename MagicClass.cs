using System;
using System.IO;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace nunit_selenium
{
    public class MagicClass
    {

        public void LoadEnvVariables()
        {
            if (!File.Exists(@"D:\test-c-sharp\nunit-selenium\.env"))
            {
                System.Console.WriteLine("true");
                return;
            }

            foreach (var line in File.ReadAllLines(@"D:\test-c-sharp\nunit-selenium\.env"))
            {
                var parts = line.Split(
                    '=',
                    StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length != 2)
                    continue;

                Environment.SetEnvironmentVariable(parts[0], parts[1]);
            }
        }
        public void FindElementAndClick(IWebDriver driver, string xPath)
        {
            driver.FindElement(By.XPath(xPath)).Click();
        }

        public IWebElement FindElement(IWebDriver driver, string xPath)
        {
            return driver.FindElement(By.XPath(xPath));
        }

        public string GetTextFromElement(IWebDriver driver, string xPath)
        {
            return driver.FindElement(By.XPath(xPath)).Text;
        }

        public void SendKeysToElement(IWebElement element, string keys)
        {
            element.SendKeys(keys);
        }
    }
}