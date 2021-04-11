using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class AlertPage: BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        private const string _youPressedCancelText = "You pressed Cancel!";
        private const string _thirdAlertText = "You have entered";
        private IWebElement _firstAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myAlertFunction()']"));
        private IWebElement _secondAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myConfirmFunction()']"));
        private IWebElement _thirdAlertButton => Driver.FindElement(By.XPath("//button[@onclick='myPromptFunction()']"));
        private IWebElement _resultBox => Driver.FindElement(By.Id("confirm-demo"));
        private IWebElement _thirdResultBox => Driver.FindElement(By.Id("prompt-demo"));

        public AlertPage(IWebDriver webdriver) : base(webdriver) { }

        public AlertPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public AlertPage ClickFirstAlertButton()
        {
            _firstAlertButton.Click();
            return this;
        }

        public AlertPage ClickSecondAlertButton()
        {
            _secondAlertButton.Click();
            return this;
        }

        public AlertPage ClickThirdAlertButton()
        {
            _thirdAlertButton.Click();
            return this;
        }

        public AlertPage AcceptFirstAlert()
        {
            Driver.SwitchTo().Alert().Accept();
            // IAlert alert = Driver.SwitchTo().Alert();
            // alert.Accept();
            return this;
        }

        public AlertPage DismissSecondAlert()
        {
            Driver.SwitchTo().Alert().Dismiss();
            return this;
        }

        public AlertPage SendKeysToThirdAlert(string text)
        {
            IAlert alert = Driver.SwitchTo().Alert();
            alert.SendKeys(text);
            alert.Accept();
            return this;
        }

        public AlertPage VerifySecondAlertText()
        {
            //Assert.AreEqual(_youPressedCancelText, _resultBox.Text, "Text is wrong");
            Assert.IsTrue(_youPressedCancelText.Equals(_resultBox.Text), "Text is wrong");
            return this;
        }

        public AlertPage VerifyThirdAlertText(string resultText)
        {
            Assert.IsTrue((_thirdAlertText + " '" + resultText + "' !").Equals(_thirdResultBox.Text), "Text is wrong");
            Assert.IsTrue(_thirdResultBox.Text.Contains(resultText), "Text is wrong");
            return this;
        }
    }
}
