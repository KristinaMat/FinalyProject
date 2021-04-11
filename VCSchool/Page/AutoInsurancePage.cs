using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class AutoInsurancePage:BasePage
    {
        private const string PageAddress = "https://www.bta.lt/lt/privatiems/transporto-draudimas/numerio-lentele";
        private IWebElement _autonumberInput => Driver.FindElement(By.Name("plateNumber"));
        private IWebElement _idnumberInput => Driver.FindElement(By.Name("vehicleOwnerIdentification"));
        private IWebElement _specialcarusageCheckBox => Driver.FindElement(By.Name("specialCarUsage"));
        private IWebElement _agreeprivacyCheckBox => Driver.FindElement(By.Name("agreePrivacyPolicy"));
        private IWebElement _calculateButton => Driver.FindElement(By.XPath("//button[contains(.,'Skaičiuoti')]"));
        private IWebElement _priceresultBox => Driver.FindElement(By.CssSelector(".policy-item:nth-child(1).num"));//nerandu elemento
      
        public AutoInsurancePage(IWebDriver webdriver) : base(webdriver) { }

        public AutoInsurancePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public AutoInsurancePage ClosePop()
        {
            GetWait(5).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Sutikti')]"))); 
            Driver.FindElement(By.XPath("//button[contains(.,'Sutikti')]")).Click();
            return this;
        }
        public AutoInsurancePage InsertAutoNumber(string autonumber)
        {
            _autonumberInput.Clear();
            _autonumberInput.SendKeys(autonumber);
            return this;
        }
        public AutoInsurancePage InsertIDNumber(string idnumber)
        {
            _idnumberInput.Clear();
            _idnumberInput.SendKeys(idnumber);
            return this;
        }
        public AutoInsurancePage UnCheckSpecialCarUsageCheckBox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _specialcarusageCheckBox.Selected)
                _specialcarusageCheckBox.Click();
            return this;
        }
        public AutoInsurancePage CheckAgreePrivacyCheckBox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _agreeprivacyCheckBox.Selected)
                _agreeprivacyCheckBox.Click();
            return this;
        }
        public AutoInsurancePage ClickCalculateButton()
        {
            _calculateButton.Click();
            return this;
        }
        public AutoInsurancePage CheckIfICanGetPolisy(int sumforpolisy)
        {
            string possiblepriceforme = _priceresultBox.Text.Trim().Replace(" ", "");
            Assert.IsTrue(sumforpolisy < GetParsedValue(possiblepriceforme), "Nope, no polisy for me");
            return this;
        }

        private int GetParsedValue(string value)
        {
            int parsedValue = 0;
            if (!"".Equals(value) && value != null)
            {
                parsedValue = Int32.Parse(value);
            }
            return parsedValue;
        }
       
    }
}
