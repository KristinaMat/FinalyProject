using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSchool
{
    public class Paskaita2Checkbox
    {
        private static IWebDriver _driver;//privatus sios klases kintamasis
        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            // WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            // wait.Until(_driver => _driver.FindElement(By.Id("at-cv-lightbox-close")).Displayed);
            // _driver.FindElement(By.Id("at-cv-lightbox-close")).Click();
        }
        [OneTimeTearDown]
        public static void TearDown()
        {
            //_driver.Quit();
        }
        [Test]
        public static void CheckOneCheckBox()
        {
            IWebElement oneCheckbox = _driver.FindElement(By.Id("isAgeSelected"));
            if (!oneCheckbox.Selected)
            {
                oneCheckbox.Click();
            }
            IWebElement rezultFromPage = _driver.FindElement(By.Id("txtAge"));
            Assert.AreEqual("Success - Check box is checked", rezultFromPage.Text, "Text is NOK");
            //Assert text 
        }

        [Test]
        public static void CheckAllCheckBoxes()
        {
            IWebElement oneCheckbox = _driver.FindElement(By.Id("isAgeSelected"));
            
            if (oneCheckbox.Selected)
            {
                oneCheckbox.Click();
            }

            IReadOnlyCollection<IWebElement> checkboxCollection = _driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement checkbox in checkboxCollection)
            {
                if (!checkbox.Selected)
                {
                    checkbox.Click();
                }
            }

            IWebElement resultButton = _driver.FindElement(By.Id("check1"));
            
            Thread.Sleep(2000);

            //Assert.IsTrue(resultButton.GetAttribute("value").Equals("Uncheck All"), $"Expected Uncheck All, but was {resultButton.GetAttribute("value")}");
            Assert.AreEqual("Uncheck All", resultButton.GetAttribute("value"), "Value is not correct");
        }

        [Test]
        public static void UnCheckAllCheckBoxes()
        {

            IWebElement oneCheckbox = _driver.FindElement(By.Id("isAgeSelected"));
            if (oneCheckbox.Selected)
            {
                oneCheckbox.Click();
            }
            IReadOnlyCollection<IWebElement> checkboxCollection = _driver.FindElements(By.CssSelector(".cb1-element"));
            foreach (IWebElement checkbox in checkboxCollection)
            {
                checkbox.Click();
            }
            IWebElement resultButton = _driver.FindElement(By.Id("check1"));
            
            Thread.Sleep(2000);

            resultButton.Click();
            Assert.AreEqual("Check All", resultButton.GetAttribute("value"), "Value is not correct");

        }
    }
}
