using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class SenukaiPage:BasePage
    {
        private const string PageAddress = "https://www.senukai.lt/";

        public SenukaiPage(IWebDriver webdriver) : base(webdriver) { }

        public SenukaiPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public SenukaiPage AcceptCookies()
        {
            Cookie myCookie = new Cookie("CookieConsent",
                "{stamp:%27oQ8JeYda/ChNOB/x8/0YY4Jxu7JgjWuJqpDoT1z7GW72/hUkPCs7UQ==%27%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:false%2Cver:1%2Cutc:1617983624705%2Cregion:%27lt%27}",
                "www.senukai.lt",
                "/",
                DateTime.Now.AddDays(5));
            Driver.Manage().Cookies.AddCookie(myCookie);
            Driver.Navigate().Refresh();
            return this;
        }
    }
}
