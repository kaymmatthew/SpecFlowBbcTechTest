using BoDi;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using SpecFlowBbcTechTest.PageObject;
using System;
using System.Reflection.PortableExecutable;
using System.Security.Policy;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using SpecFlowBbcTechTest.Extension;
using System.Runtime.Intrinsics.Arm;

namespace SpecFlowBbcTechTest.StepDefinitions
{
    [Binding]
    public class CreateUserOnBBCLoginPageStepDefinitions
    {
        IWebDriver driver;
        ScenarioContext _scenarioContext;
        BbcHomePage bbcHomePage;
        BbcRegisterPage bbcRegisterPage;
        BbcSignInOrRegisterPage bbcSignInOrRegisterPage;

        public CreateUserOnBBCLoginPageStepDefinitions(IObjectContainer _container)
        {
            _scenarioContext = _container.Resolve<ScenarioContext>();
            bbcHomePage = _container.Resolve<BbcHomePage>();
            bbcRegisterPage = _container.Resolve<BbcRegisterPage>();
            driver = _container.Resolve<IWebDriver>();
            bbcSignInOrRegisterPage = _container.Resolve<BbcSignInOrRegisterPage>();
        }

        [Given(@"I am on bbc\.co\.uk home page")]
        public void GivenIAmOnBbc_Co_Uk() => bbcHomePage.navigateToSite();

        [When(@"I click on sign in button from the navigation bar")]
        public void ClickOnSignInButtonFromTheNavigationBar() => bbcHomePage.clickSignInButton();

        [Then(@"I am on BBC (.*) page")]
        public void BBCSignInPageIsDisplayed(string pageHeader)
        {
            string actualValue = bbcSignInOrRegisterPage.getSignInHeaderText();
            Assert.AreEqual(pageHeader, actualValue);
        }

        [When(@"I click on register now button")]
        public void ThenIClickOnRegisterNowButton() => bbcSignInOrRegisterPage.clickRegisterNewButton();
     
        [Then(@"(.*) is displayed")]
        public void ThenIAmOnRegisterWithTheBBCPage(string expectedValue)
        {
            CustomExtension.WaitFor(driver, 1);
            var actualValue = bbcRegisterPage.getRegisterHeaderText();
            Assert.AreEqual(expectedValue, actualValue);
        }

        [When(@"I Click 13 or over button")]
        public void ThenISelectOrOverButton() => bbcRegisterPage.ClickThirTeenOrOverButton();

        [When(@"I enters details for date of birth")]
        public void ThenIEntersDetailsForDateOfBirth(Table table)
        {
            var tableDetails = table.CreateInstance<date>();
            bbcRegisterPage.EnterDateOfBirthDetails(tableDetails.Day, tableDetails.Month, tableDetails.Year);
        }

        public record date
        {
            public string? Day { get; set; }
            public string? Month { get; set; }
            public string? Year { get; set; }
        }

        [When(@"I click Continute button")]
        public void ThenIClickContinuteButton() => bbcRegisterPage.ClickContinueButton();

        [When(@"I enters the following details:")]
        public void ThenIEntersTheFollowingDetails(Table table)
        {
            dynamic enterDetails = table.CreateDynamicInstance();
            var radom = new Random().Next(0, 999);
            bbcRegisterPage.EnterDetails(string.Format(enterDetails.Email, radom.ToString()), enterDetails.Password, enterDetails.Postcode);
        }

        [When(@"I select (.*)")]
        public void ThenISelectMaleAsGender(string option) => bbcRegisterPage.ClickGender(option);

        [When(@"I click register")]
        public void ThenIClickRegister() => bbcRegisterPage.ClickRegisterSubBtn();

        [Then(@"A text is displayed '([^']*)'")]
        public void ThenATextIsDisplayed(string expectedText)
        {
            CustomExtension.WaitFor(driver, 1);
            var actualValue = bbcRegisterPage.getRegisterHeaderText();
            Assert.AreEqual(expectedText, actualValue);
        }
    }
}