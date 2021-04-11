using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VCSchool.Page;

namespace VCSchool.Test
{
    public class BrowsersDemoTest
    {
        private static IWebDriver _driver;

        [TearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("Chrome", TestName = "Testing Chrome")]
        [TestCase("Firefox", TestName = "Testing Firefox")]
        public static void TestSum(String browser)
        {
            if ("Chrome".Equals(browser))
                _driver = new ChromeDriver();
            if ("Firefox".Equals(browser))
                _driver = new FirefoxDriver();

            BrowsersDemoPage _page = new BrowsersDemoPage(_driver);
            _page.Navigate()
                .VerifyText(browser);
        }
    }
}
