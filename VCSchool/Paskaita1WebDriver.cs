using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSchool
{
    public class Paskaita1WebDriver
    {
        [Test]
        public static void TestYahooPage()
        {
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://login.yahoo.com/";
            IWebElement loginInputField = chrome.FindElement(By.Id("login-username"));
            loginInputField.SendKeys("Test");
            //chrome.Close();
        }
        [Test]
        public static void TestSeleniumPage()
        {
            
            IWebDriver chrome = new ChromeDriver();
            chrome.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
            Thread.Sleep(5000);//palaukiam, kol atsidarys popup
            IWebElement popUp = chrome.FindElement(By.Id("at-cv-lightbox-close"));//surandame ji
            if (popUp.Displayed)
                popUp.Click();//uzdarome
            IWebElement InputField = chrome.FindElement(By.Id("user-message"));
            string myText = "Labas";
            InputField.SendKeys(myText);
            IWebElement button = chrome.FindElement(By.CssSelector("#get-input>button"));
            button.Click();
            IWebElement result = chrome.FindElement(By.Id("display"));
            Assert.AreEqual(myText, result.Text, "Tekstas neatsirado");
                //chrome.Quit();



        }
    }
}
