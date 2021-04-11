using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class ContactToBTAPage: BasePage
    {
        private const string PageAddress = "https://www.bta.lt/lt/atstovybes";
        private SelectElement _cityBtaBranch => new SelectElement(Driver.FindElement(By.Id("")));
        public ContactToBTAPage(IWebDriver webdriver) : base(webdriver) { }

        public ContactToBTAPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        public ContactToBTAPage ClosePop()//uzdarom poput
        {
            GetWait(5).Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(.,'Sutikti')]"))); //lauksime popup
            Driver.FindElement(By.XPath("//button[contains(.,'Sutikti')]")).Click();//kai pamatom-uzdarome
            return this;
        }

    }
}
