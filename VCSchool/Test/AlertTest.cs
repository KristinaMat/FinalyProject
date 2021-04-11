using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCSchool.Test
{
    public class AlertTest:BaseTest
    {
        [Test]
        public static void TestFirstAlertBox()
        {
            _alertPage.NavigateToDefaultPage()
                .ClickFirstAlertButton()
                .AcceptFirstAlert();
        }

        [Test]
        public static void TestSecondAlertBox()
        {
            _alertPage.NavigateToDefaultPage()
                .ClickSecondAlertButton()
                .DismissSecondAlert()
                .VerifySecondAlertText();
        }

        [TestCase("Alert", TestName = "Alert test with SendKeys method")]
        public static void TestThirdAlertBox(string text)
        {
            _alertPage.NavigateToDefaultPage()
                .ClickThirdAlertButton()
                .SendKeysToThirdAlert(text)
                .VerifyThirdAlertText(text);
        }
    }
}
