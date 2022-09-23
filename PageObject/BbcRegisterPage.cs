using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SpecFlowBbcTechTest.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBbcTechTest.PageObject
{
    public class BbcRegisterPage
    {
        IWebDriver driver;
        ScenarioContext _scenarioContext;
        public BbcRegisterPage(IObjectContainer _container)
        {
            _scenarioContext = _container.Resolve<ScenarioContext>();
            driver = _container.Resolve<IWebDriver>();
        }

        private IWebElement RegisterHeaderText => driver.FindElement(By.XPath("//h1[@class='sb-heading--headlineSmall sb-heading--bold']/."));
        private IWebElement ThirTeenOrOverButton => driver.FindThisElement(By.XPath("//a[contains(@class, 'sb')][.='13 or over']"));
        private IWebElement DayOfBirthDay => driver.FindThisElement(By.Id("day-input"));
        private IWebElement MonthOfBirthDay => driver.FindThisElement(By.Id("month-input"));
        private IWebElement YearOfBirthDay => driver.FindThisElement(By.Id("year-input"));
        private IWebElement ContinueButton => driver.FindElement(By.XPath("//button[@id='submit-button'][.='Continue']"));
        private IWebElement Email => driver.FindElement(By.Id("user-identifier-input"));
        private IWebElement Password => driver.FindElement(By.Id("password-input"));
        private IWebElement PostCode => driver.FindElement(By.Id("postcode-input"));
        private IWebElement GenderSelection => driver.FindElement(By.XPath("//select[contains(@id, 'gender-input')]"));
        private IWebElement RegisterSubmit => driver.FindElement(By.XPath("//button[contains(@id,\"submit\")][.='Register']"));
        private IWebElement okYouAreSignInText => driver.FindElement(By.XPath(
            "//h1[@class='sb-heading--headlineSmall sb-heading--bold']/."));
    





        public string getRegisterHeaderText() => RegisterHeaderText.Text;
        public void ClickThirTeenOrOverButton() => ThirTeenOrOverButton.ClickViaJs(driver);
        public void ClickContinueButton() => ContinueButton.Click();
        public void ClickRegisterSubBtn() => RegisterSubmit.Click();
        public string OkYouAreSignInTextDisplayed() => okYouAreSignInText.Text;
        public void ClickGender(string text) => new SelectElement(GenderSelection).SelectByText(text);

        public void EnterDateOfBirthDetails(string day, string month, string year)
        {
            CustomExtension.WaitFor(driver, 2);
            DayOfBirthDay.SendKeys(day);
            MonthOfBirthDay.SendKeys(month);
            YearOfBirthDay.SendKeys(year);
        }
        public void EnterDetails(string email,string password, string postcode)
        {
            Email.SendKeys(email);
            Password.SendKeys(password);
            PostCode.SendKeys(postcode);
            _scenarioContext.Add("userEmail", email);
            _scenarioContext.Add("userPassword", password);
        }
    }
}