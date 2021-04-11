using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool
{
    public class Paskaita2HWVera
    {
        private static IWebDriver _driver;//privatus sios klases kintamasis
        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => _driver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            _driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }

        [TestCase("2", "2", "4", TestName ="2 plus 2 eq 4")]
        [TestCase("-5", "3", "-2", TestName = "-5 plus 3 eq -2")]
        [TestCase("a", "b", "NaN", TestName = "a plus b eq NaN")]
        public static void TestSum(string firstInput, string secondInput, string result)//metodas, kad testcase duomenis paiimtu
        {
            IWebElement firstInputField = _driver.FindElement(By.Id("sum1"));
            IWebElement secondInputField = _driver.FindElement(By.Id("sum2"));
            firstInputField.Clear();
            firstInputField.SendKeys(firstInput);//paiima kintamaji
            secondInputField.Clear();
            secondInputField.SendKeys(secondInput);
            _driver.FindElement(By.CssSelector("#gettotal>button")).Click();
            IWebElement resultFromPage = _driver.FindElement(By.Id("displayvalue"));
            Assert.AreEqual(result, resultFromPage.Text, "Result is NOK");
        }
       
    }
}
