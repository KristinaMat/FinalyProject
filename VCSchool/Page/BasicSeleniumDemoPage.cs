using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class BasicSeleniumDemoPage
    {
        private static IWebDriver _driver;

        private IWebElement _InputField => _driver.FindElement(By.Id("user-message"));//elemento priskirimas per rodykles Page =>,kai pradedame atitinkama metoda naudoti
        private IWebElement _button => _driver.FindElement(By.CssSelector("#get-input>button"));
        private IWebElement _resultFromPage => _driver.FindElement(By.Id("display"));
        private IWebElement _firstInputField => _driver.FindElement(By.Id("sum1"));
        private IWebElement _secondInputField => _driver.FindElement(By.Id("sum2"));
        private IWebElement _getTotalButton=>_driver.FindElement(By.CssSelector("#gettotal>button"));
        private IWebElement _sumResultFromPage => _driver.FindElement(By.Id("displayvalue"));


        public BasicSeleniumDemoPage(IWebDriver webdriver)//konstruktorius, kad paduotu narsykle
        {
            _driver = webdriver;
        }
        public void InsertTextToInputField(string text)//metodas irasyti teksta i laukelius
        {
            _InputField.Clear();
            _InputField.SendKeys(text);
        }
        public void ClickShowMessageButton()//metodas paspausti mygtuka
        {
            _button.Click();
        }
        public void Verifyresult(string result)//metodas sutikrinti rezultata
        {
            Assert.AreEqual(result, _resultFromPage.Text, "Text is not the same");
        }

        public void InsertBothValuesToInputFields(string firstInput, string secondInput)//metodas iraso iskarto i abu laukelius
        {
            InserTextToFirsInputField(firstInput);//isvieciu apsirasytus metodus
            InserTextToSecondInputField(secondInput);
        }
        public void ClickGetTotalButton()
        {
            _getTotalButton.Click();
        }
        public void VerifySumResult(string result)
        {
            Assert.AreEqual(result, _sumResultFromPage.Text, "Result is NOK");
        }
        private void InserTextToFirsInputField(string text)
        {
            _firstInputField.Clear();
            _firstInputField.SendKeys(text);
        }
        private void InserTextToSecondInputField(string text)
        {
            _secondInputField.Clear();
            _secondInputField.SendKeys(text);
        }

    }
}
