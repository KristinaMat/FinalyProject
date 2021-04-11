using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Test
{
    public class TravelInsuranceTest:BaseTest
    {
        [Test]
        public static void CalculateTravelInsurance()
        {
            _travelInsurancePage.NavigateToDefaultPage()
                .ClosePop()
                .ClickGoToCalculateButton()
                .SwitchToFrame()
                .InsertFromData("2021-04-15")
                .InsertTillData("2021-04-19")
                .CheckAllWorldCheckBox()
                .SelectTravelerNumber()
                .CheckTravelPurposeCheckBox()
                .ClickCalculateButton();           
        }
    }
}
