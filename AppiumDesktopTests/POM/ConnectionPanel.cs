using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDesktopTests.POM
{
    public class ConnectionPanel :BasePanel
    {
        public ConnectionPanel(WindowsDriver<WindowsElement> driver) : base(driver) 
        {
        
        }

        public void ConnectToUrl(string url = "https://contactbook.velio4ka.repl.co/api")
        {
            var inputField = this.driver.FindElementByAccessibilityId("textBoxApiUrl");
            inputField.SendKeys(url);

            this.driver.FindElementByAccessibilityId("buttonConnect").Click();
        }
    }
}
