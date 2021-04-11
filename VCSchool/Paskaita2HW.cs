using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool
{
    class Paskaita2HW
    {
        [Test]
        public static void Test2Plus2Sum()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement firstInputField = chrome.FindElement(By.Id("sum1"));
            IWebElement secondInputField = chrome.FindElement(By.Id("sum2"));
            firstInputField.SendKeys("2");
            secondInputField.SendKeys("2");
            chrome.FindElement(By.CssSelector("#gettotal>button")).Click();//surandam elementa ir spaudziam Click, tai darome kai yra viena karta naudojam elementa, nekuriame
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("4", result.Text, "Result is NOK");//.Text metodas palyginimui
            chrome.Quit();
        }
        [Test]
        public static void Testminus5Plus3Sum()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement firstInputField = chrome.FindElement(By.Id("sum1"));
            IWebElement secondInputField = chrome.FindElement(By.Id("sum2"));
            firstInputField.SendKeys("-5");
            secondInputField.SendKeys("3");
            chrome.FindElement(By.CssSelector("#gettotal>button")).Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("-2", result.Text, "Result is NOK");
            chrome.Quit();
        }
        [Test]
        public static void TestAPlusBSum()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            IWebElement firstInputField = chrome.FindElement(By.Id("sum1"));
            IWebElement secondInputField = chrome.FindElement(By.Id("sum2"));
            firstInputField.SendKeys("a");
            secondInputField.SendKeys("b");
            chrome.FindElement(By.CssSelector("#gettotal>button")).Click();
            IWebElement result = chrome.FindElement(By.Id("displayvalue"));
            Assert.AreEqual("NaN", result.Text, "Result is NOK");
            chrome.Quit();
        }
    }
}
