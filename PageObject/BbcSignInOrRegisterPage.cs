using OpenQA.Selenium;
using SpecFlowBbcTechTest.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBbcTechTest.PageObject
{
    public class BbcSignInOrRegisterPage
    {
        IWebDriver driver;
        public BbcSignInOrRegisterPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement SignInHeaderText => driver.FindElement(By.XPath("//h1[contains(@class, 'heading')][.='Sign in']"));
        private IWebElement RegisterNowButton => driver.FindElement(By.XPath("//a[contains(@class, 'sb')][.='Register now']"));
        private IWebElement EnterUserEmail => driver.FindThisElement(By.XPath("//input[@id='user-identifier-input']"));
        private IWebElement EnterUserPassword => driver.FindThisElement(By.XPath("//input[@id='password-input']"));
        private IWebElement SignInBtn => driver.FindThisElement(By.Id("submit-button"));



        public void enterUserEmail(string userEmail) => EnterUserEmail.SendKeys(userEmail);
        public void enterUserPassword(string userPassword) => EnterUserPassword.SendKeys(userPassword);
        public void clikSignInBtn() => SignInBtn.Click();
        public string getSignInHeaderText() => SignInHeaderText.Text;
        public void clickRegisterNewButton() => RegisterNowButton.Click();
    }
}