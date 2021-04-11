using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace VCSchool
{
    public class HW2Page
    {
        private static IWebDriver _driver;
        [Test]
        public static void TestChromebrowser()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement result = _driver.FindElement(By.CssSelector("#primary-detection>div"));
            Assert.AreEqual("Chrome 89 on Windows 10", result.Text, "Result is NOK");
            _driver.Quit();
        }
        private static IWebDriver driver;
        [Test]
        public static void TestFirefoxbrowser()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            IWebElement result = driver.FindElement(By.CssSelector("#primary-detection>div"));
            Assert.AreEqual("Firefox 87 on Windows 10", result.Text, "Result is NOK");
            driver.Quit();
        }
    }
}
