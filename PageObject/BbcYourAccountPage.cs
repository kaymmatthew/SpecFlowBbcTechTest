using BoDi;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBbcTechTest.PageObject
{
    public class BbcYourAccountPage
    {
        IWebDriver driver;
        public BbcYourAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement YourAccountHeaderText => driver.FindElement(By.XPath("//h1[contains (@class, 'heading')][.='Your account']"));
        private IWebElement SignOutBtn => driver.FindElement(By.XPath("//a[contains(@class, 'link link')][.='Sign out']"));


        public string getYourAccountHeaderText() => YourAccountHeaderText.Text;
        public void clickSignOutBtn() => SignOutBtn.Click();

    }
}