using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class TravelInsurancePage:BasePage
    {
        private const string PageAddress = "https://www.bta.lt/lt/privatiems/kelioniu-draudimas";
        private IWebElement _gotocalculateButton => Driver.FindElement(By.XPath("//button[contains(.,'Pasiskaičiuoti įmoka')]"));
        private IWebElement _fromdateInput => Driver.FindElement(By.XPath("//input"));
        private IWebElement _tilldateInput => Driver.FindElement(By.XPath("//div[2]/input"));
        private IWebElement _allWorldCheckBox => Driver.FindElement(By.Id("rb-VISASP"));
        private IWebElement _selectTravelerNumberButton => Driver.FindElement(By.CssSelector(".hidden-xs.arrow"));
        private IWebElement _wintersportCheckBox => Driver.FindElement(By.Id("rb-SPORT"));
        private IWebElement _calculateButton => Driver.FindElement(By.CssSelector(".text-uppercase>span"));




        public TravelInsurancePage(IWebDriver webdriver) : base(webdriver) { }

        public TravelInsurancePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public TravelInsurancePage ClosePop()//uzdarom poput
        {
            GetWait(5).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Sutikti')]"))); 
            Driver.FindElement(By.XPath("//button[contains(.,'Sutikti')]")).Click();
            return this;
        }

        public TravelInsurancePage ClickGoToCalculateButton()
        {
            _gotocalculateButton.Click();
            return this;
        }
        public TravelInsurancePage SwitchToFrame()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(By.XPath("//*[@id=module-528]/div/div/iframe")));
            return this;
        }
        public TravelInsurancePage InsertFromData(string datafrom)
        {
            _fromdateInput.Clear();
            _fromdateInput.SendKeys(datafrom);
            return this;
        }
        public TravelInsurancePage InsertTillData(string datatill)
        {
            _tilldateInput.Clear();
            _tilldateInput.SendKeys(datatill);
            return this;
        }
        public TravelInsurancePage CheckAllWorldCheckBox()
        {
            if (!_allWorldCheckBox.Selected)
                _allWorldCheckBox.Click();
            return this;
        }
        public TravelInsurancePage SelectTravelerNumber()
        {
            _selectTravelerNumberButton.Click();
            return this;
        }
        public TravelInsurancePage CheckTravelPurposeCheckBox()
        {
            if (!_wintersportCheckBox.Selected)
                _wintersportCheckBox.Click();
            return this;
        }
        public TravelInsurancePage ClickCalculateButton()
        {
            _calculateButton.Click();
            return this;
        }

    }
}
