using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    class BasicCheckboxDemoTest
    {
        private static BasicCheckboxDemoPage _page; //klases lygio kintamasis, kuris paveldi BasePage per Page klase

        [OneTimeSetUp]
        public static void SetUp()
        {
            IWebDriver driver = new ChromeDriver();//lokalus tik sio metodo
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _page = new BasicCheckboxDemoPage(driver);//kuriame nauja objekta ir perduodame driver, tada nereikia prie kiekvieno testo kurti naujo objekto
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _page.CloseBrowser();//metodas is Base Page
        }

        [Test]
        public static void SingleCheckBoxTest()
        {
            _page.CheckSingleCheckBox()
                    .AssertSingleCheckBoxDemoSuccessMessage()
                    .UnCheckSingleCheckBox();
        }

        [Test]
        public static void MultipleCheckBoxTest()
        {
            _page.CheckAllMultipleCheckBoxes()
                .AssertButtonName("Uncheck All");
        }

        [Test]
        public static void UncheckMultipleCheckBoxesTest()
        {
            _page.CheckAllMultipleCheckBoxes()
                .ClickGroupButton()
                .AssertMultipleCheckBoxesUnchecked();
        }
    }
}
