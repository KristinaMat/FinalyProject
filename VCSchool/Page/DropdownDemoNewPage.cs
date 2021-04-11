using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Page
{
    public class DropdownDemoNewPage: BasePage
    {
        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private const string ResultText = "Day selected :- ";
        private SelectElement DropDown => new SelectElement(Driver.FindElement(By.Id("select-demo")));
        private IWebElement ResultTextElement => Driver.FindElement(By.CssSelector(".selected-value"));
        private IWebElement ResultTextAllSelectedElement => Driver.FindElement(By.CssSelector(".getall-selected"));

        private SelectElement MultiDropDown => new SelectElement(Driver.FindElement(By.Id("multi-select")));

        private IWebElement FirstSelectedButton => Driver.FindElement(By.Id("printMe"));

        private IWebElement GetAllSelectedButton => Driver.FindElement(By.Id("printAll"));

        public DropdownDemoNewPage(IWebDriver webdriver) : base(webdriver) { }//konstruktorius

        public DropdownDemoNewPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public DropdownDemoNewPage SelectFromDropdownByText(string text)
        {
            DropDown.SelectByText(text);
            return this;
        }

        public DropdownDemoNewPage SelectFromDropdownByValue(string text)//metodas pazymejimui
        {
            DropDown.SelectByValue(text);
            return this;
        }

        public DropdownDemoNewPage VerifyResult(string selectedDay)//metodas patikrinimui
        {
            Assert.AreEqual(ResultText + selectedDay, ResultTextElement.Text, $"Result is wrong, not {selectedDay}");
            return this;
        }

        public DropdownDemoNewPage SelectFromMultipleDropdownAndClickFirstButton(List<string> listOfStates)//metodas darbui su viso saraso eleentais
        {
            MultiDropDown.DeselectAll();
            Actions action = new Actions(Driver);//naujas kintamas,objektas
            action.KeyDown(Keys.LeftControl);// mygtukas ctr
            foreach (string state in listOfStates)//einu per sarasa, tam kad atrasti eiliskuma, ka pirma paspaudziame sarase
            {
                foreach (IWebElement option in MultiDropDown.Options)//eiti per visus saraso elementus-dropdownus-salys
                {
                    if (state.Equals(option.GetAttribute("value")))//jei sarase turiu tokia reiksme
                    {
                        action.Click(option);//pazymek ja
                        break;
                    }
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click(FirstSelectedButton);//atrandame, ka pirma paspaudziame
            action.Build().Perform();
            return this;
        }

        public DropdownDemoNewPage ClickGetAllButton()
        {
            GetAllSelectedButton.Click();
            return this;
        }

        public DropdownDemoNewPage CheckListedStates(List<string> selectedElements)
        {
            string result = ResultTextAllSelectedElement.Text;
            foreach (string selectedElement in selectedElements)
            {
                Assert.True(result.Contains(selectedElement),
                    $"Should be {selectedElement}, but was {result}");
            }
            return this;
        }

        public DropdownDemoNewPage CheckFirstState(string selectedElement)
        {
            string result = ResultTextAllSelectedElement.Text;
            Assert.True(result.Contains(selectedElement),
                $"{selectedElement} is missing. {result}");
            return this;
        }

        public DropdownDemoNewPage SelectFromMultipleDropdownByValue(List<string> listOfStates)
        {
            MultiDropDown.DeselectAll();//reikia isvalyti sarasa
            foreach (IWebElement option in MultiDropDown.Options)
                if (listOfStates.Contains(option.GetAttribute("value")))
                {
                    ClickMultipleBox(option);
                }
            return this;
        }

        private void ClickMultipleBox(IWebElement element)
        {
            Actions actions = new Actions(Driver);
            actions.KeyDown(Keys.Control);
            actions.Click(element);
            actions.KeyUp(Keys.Control);
            actions.Build().Perform();
        }
    }
}
