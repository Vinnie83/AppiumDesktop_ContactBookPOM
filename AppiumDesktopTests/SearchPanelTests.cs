using AppiumDesktopTests.POM;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumDesktopTests
{
    internal class SearchPanelTests
    {

        private WindowsDriver<WindowsElement> connectionPanelDriver;
        private WindowsDriver<WindowsElement> searchPanelDriver;
        private AppiumOptions options;
        private string url = "http://127.0.0.1:4723/wd/hub";
        private string appPath = @"C:\ContactBook-DesktopClient.NET6\ContactBook-DesktopClient.exe";
        private SearchPanel searchPanel;
        private ConnectionPanel connectionPanel;

        [SetUp]
        public void Setup()
        {
            this.options = new AppiumOptions()
            {
                PlatformName = "Windows"
            };

            this.options.AddAdditionalCapability("app", appPath);
            this.connectionPanelDriver = new WindowsDriver<WindowsElement>(new Uri(url), options);
            this.connectionPanel = new ConnectionPanel(this.connectionPanelDriver);
            connectionPanelDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5000);

            this.options.AddAdditionalCapability("app", "Root");

            this.searchPanelDriver = new WindowsDriver<WindowsElement>(new Uri(url), options);
            this.searchPanelDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); 
            this.searchPanel = new SearchPanel(this.searchPanelDriver);
        }

        [TearDown]
        public void CloseApplication()
        {
            this.searchPanel.Close();
        }

        [Test]
        public void FirstResultShouldBeSteveJobs()
        {
            var expectedResult = "Steve Jobs";
            this.connectionPanel.ConnectToUrl();

            this.searchPanel.SearchInput.SendKeys("steve");
            this.searchPanel.SearchButton.Click();

            var actualResult = this.searchPanel.GetActualResult();

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
