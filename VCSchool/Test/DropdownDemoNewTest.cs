using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Test
{
    public class DropdownDemoNewTest: BaseTest
    {
        [Test]
        public void TestDropdown()
        {
            _dropdownDemoPage.NavigateToDefaultPage()
                .SelectFromDropdownByText("Friday")
                .VerifyResult("Friday");
        }

        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname pirma pasirinkima")]
        [TestCase("Washington", "Ohio", "Texas", TestName = "Pasirenkame 3 reiksmes ir patikriname pirma pasirinkima")]
        public void TestMultipleDropdown(params string[] selectedElements)//paduodame masyva ir parametrizuojame, kai nesirisame prie skaiciaus kuri norime paduoti testui
        {
            _dropdownDemoPage.NavigateToDefaultPage()
                .SelectFromMultipleDropdownAndClickFirstButton(selectedElements.ToList())
                .CheckFirstState(selectedElements[0]);

        }

        [TestCase("New Jersey", "California", TestName = "Pasirenkame 2 reiksmes ir patikriname visus pasirinkimus")]
        [TestCase("Washington", "Ohio", "Texas", "Florida", TestName = "Pasirenkame 4 reiksmes ir patikriname visus pasirinkimus")]
        public void TestMultipleDropdownGetAll(params string[] selectedElements)//params kad galetu paiiimtimasyvo elementus salis kaip stringa atskirai
        {
            _dropdownDemoPage.NavigateToDefaultPage()
                .SelectFromMultipleDropdownByValue(selectedElements.ToList())
                .ClickGetAllButton()
                .CheckListedStates(selectedElements.ToList());
        }
    }
}
