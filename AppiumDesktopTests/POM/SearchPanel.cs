using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDesktopTests.POM
{
    public class SearchPanel :BasePanel
    {

        public SearchPanel(WindowsDriver<WindowsElement> driver)
           : base(driver)
        {
        }

        public WindowsElement SearchInput => this.driver.FindElementByAccessibilityId("textBoxSearch");
        public WindowsElement SearchButton => this.driver.FindElementByAccessibilityId("buttonSearch");

        public string GetActualResult()
        {
            var resultTableElement = this.driver.FindElementByAccessibilityId("dataGridViewContacts");

            var actualFirstName = resultTableElement.FindElementByName("FirstName Row 0, Not sorted.").Text;
            var actualLastName = resultTableElement.FindElementByName("LastName Row 0, Not sorted.").Text;

            return $"{actualFirstName} {actualLastName}";
        }

        public void Close()
        {
            var bar = this.driver.FindElementByAccessibilityId("TitleBar");

            try
            {
                bar.FindElementByXPath("//Button[@Name=\"Затвори\"]").Click();
            }
            catch (Exception)
            {
                bar.FindElementByXPath("//Button[@Name=\"Close\"]").Click();
            }
        }

    }
}
