using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDesktopTests.POM
{
    public abstract class BasePanel
    {
        protected WindowsDriver<WindowsElement> driver; 

        protected BasePanel(WindowsDriver<WindowsElement> driver) 
        { 
            this.driver = driver;
        }   


    }
}
