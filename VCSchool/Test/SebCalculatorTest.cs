using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Test
{
    public class SebCalculatorTest: BaseTest
    {
        [Test]
        public static void CalculateLoan()
        {
            _sebCalculatorPage.NavigateToDefaultPage()
                .ClosePop()
                .SwitchToFrame()
                .InsertIncome("1000")
                .SelectFromCityDropdownByValue("Klaipeda")
                .ClickCalculateButton()
                .CheckIfICanGetLoan(75000);
        }

        
    }
}
