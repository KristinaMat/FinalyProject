using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class BasePage
    {
        protected static IWebDriver Driver;//kintamasis, kuri paveldes 
        public BasePage(IWebDriver webdriver)//konstruktorius
        {
            Driver = webdriver;
        }
        public void CloseBrowser()
        {
            Driver.Quit();
        }
        public WebDriverWait GetWait(int seconds = 5)//laukimo metodas kai reikia teste stabilumo ar kol pasirodys elementai, vietoje Thread.Sleep
        {
            return new WebDriverWait(Driver, TimeSpan.FromSeconds(seconds));//metode galesime nurodyti konkrecias sekundes, jei nenurodysime bus 5 sek laukimo
        }

    }
}
