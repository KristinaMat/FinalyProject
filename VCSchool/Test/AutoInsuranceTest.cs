using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Test
{
    public class AutoInsuranceTest : BaseTest
    {
       
        [TestCase("JPS211", "47805120402", false, true, 100, TestName = "Ar turėdama 100 eurų apdrausiu mašiną privalomuoju draudimu metams")]

        public static void CalculateAutoInsurance(string autonumber, string idnumber, bool specialusage, bool agreeprivacy, int sumforpolicy)
        {
            _autoInsurancePage.NavigateToDefaultPage()
                .ClosePop()
                .InsertAutoNumber(autonumber)
                .InsertIDNumber(idnumber)
                .UnCheckSpecialCarUsageCheckBox(specialusage)
                .CheckAgreePrivacyCheckBox(agreeprivacy)
                .ClickCalculateButton()
                .CheckIfICanGetPolisy(sumforpolicy);
        }
        
    }
}
