using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBbcTechTest.PageObject
{
    public class BbcSignOutPage
    {
        IWebDriver driver;
        public BbcSignOutPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement YouHaveSignOutHeaderText => driver.FindElement(By.XPath("//h1[@class='heading u-padding-bottom-quad']"));
        private IWebElement ContinueButton => driver.FindElement(By.XPath("//a[contains(@class, 'button')][.='Continue']"));


        public string getYouHaveSignOutHeaderText() => YouHaveSignOutHeaderText.Text;
        public void clickContinueButton() => ContinueButton.Click();

    }
}