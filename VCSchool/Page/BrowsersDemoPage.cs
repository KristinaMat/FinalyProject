using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class BrowsersDemoPage : BasePage
    {
        private IWebElement _actualResult => Driver.FindElement(By.CssSelector("#primary-detection > div"));

        public BrowsersDemoPage(IWebDriver webdriver) : base(webdriver) { }

        public BrowsersDemoPage Navigate()
        {
            Driver.Navigate().GoToUrl("https://developers.whatismybrowser.com/useragents/parse/?analyse-my-user-agent=yes#parse-useragent");
            return this;
        }

        public BrowsersDemoPage VerifyText(string browserName)
        {
            Assert.IsTrue(_actualResult.Text.Contains(browserName), $"Browser is not {browserName}");
            return this;
        }
    }
}
