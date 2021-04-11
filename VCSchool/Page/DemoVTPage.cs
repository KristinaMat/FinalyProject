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
    public class DemoVTPage: BasePage//paveldejimas is bazines klases
    {
        private const string PageAddress = "http://vartutechnika.lt/";//jei testuojame kontaktus, tai cia rasome nuoroda i kontaktus
        private IWebElement _widthInputField => Driver.FindElement(By.Id("doors_width"));
        private IWebElement _heightInputField => Driver.FindElement(By.Id("doors_height"));
        private IWebElement _autoCheckbox => Driver.FindElement(By.Id("automatika"));
        private IWebElement _worksCheckbox => Driver.FindElement(By.Id("darbai"));
        private IWebElement _calculateButton => Driver.FindElement(By.Id("calc_submit"));
        private IWebElement _resultBox => Driver.FindElement(By.CssSelector(".col-md-12.alert.alert-success"));

        public DemoVTPage(IWebDriver webdriver) : base(webdriver) { }//konstruktoriai turi buti tusti

        public DemoVTPage NavigateToHomePage()//nevisada reikia eiti home page
        {
            if (Driver.Url != PageAddress)//patikrinimas ar mes neesame home page, nereikia refresinti puslapio
                Driver.Url = PageAddress;
            return this;
        }

        public DemoVTPage InsertWidth(string width)
        {
            _widthInputField.Clear();
            _widthInputField.SendKeys(width);
            return this;
        }

        public DemoVTPage InsertHeight(string height)
        {
            _heightInputField.Clear();
            _heightInputField.SendKeys(height);
            return this;
        }

        public DemoVTPage InsertWidthAndHeight(string width, string height)
        {
            InsertWidth(width);
            InsertHeight(height);
            return this;
        }

        public DemoVTPage CheckAutoCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _autoCheckbox.Selected)
                _autoCheckbox.Click();
            return this;
        }

        public DemoVTPage CheckWorksCheckbox(bool shouldBeChecked)
        {
            if (shouldBeChecked != _worksCheckbox.Selected)
                _worksCheckbox.Click();
            return this;
        }

        public DemoVTPage ClickCalculateButton()
        {
            _calculateButton.Click();
            return this;
        }

        public DemoVTPage CheckResult(string result)
        {
            WaitForElementToBeDisplayed(_resultBox);
            Assert.IsTrue(_resultBox.Text.Contains(result), $"Failed, expected result was {result}, but actual result was {_resultBox.Text}");
            return this;
        }

        private void WaitForElementToBeDisplayed(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(_driver => element.Displayed);
        }
    }
}
