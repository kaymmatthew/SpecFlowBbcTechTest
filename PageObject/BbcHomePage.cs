using OpenQA.Selenium;
using SpecFlowBbcTechTest.Extension;
using SpecFlowBbcTechTest.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBbcTechTest.PageObject
{
    public class BbcHomePage
    {
        IWebDriver driver;
        public BbcHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private IWebElement SignInButton => driver.FindThisElement(By.XPath("//a[contains(@class, 'ssrcss')][.='Sign in']"));
        private IWebElement YourAccountButton => driver.FindThisElement(By.XPath("//a[contains(@class, 'ssrcss')][.='Your account']"));
        private IWebElement WelcomeToBbcHeaderText => driver.FindElement(By.XPath("//div[contains(@class, 'ssrcss-1jv')][.='Welcome to the BBC']"));
        private IList<IWebElement> CommentsIcon => driver.FindElements(By.XPath(
            "//*[@class= 'ssrcss-y6cp74-Grid e12imr580' ] //li//div[@class='ssrcss-13nu8ri-GroupChildrenForWrapping e1ojgjhb2']"));


        public void clickSignInButton() => SignInButton.Click();
        public void clickYourAccountButton() => YourAccountButton.Click();
        public IList<IWebElement> isCommentIconEnabled() => CommentsIcon;

        public string getWelcomeToBbcHeaderText() => WelcomeToBbcHeaderText.Text;
        public void navigateToSite() => driver.Navigate().GoToUrl(readTestDataConfig.bbcUrl);
    }
}