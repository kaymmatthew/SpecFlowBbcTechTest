using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlowBbcTechTest.PageObject;
using System;
using System.Reflection.PortableExecutable;
using TechTalk.SpecFlow;

namespace SpecFlowBbcTechTest.StepDefinitions
{
    [Binding]
    public class UserSigninSuccessfullyStepDefinitions
    {
        ScenarioContext _scenarioContext;
        BbcHomePage bbcHomePage;
        BbcSignOutPage bbcSignOutPage;
        BbcYourAccountPage bbcYourAccountPage;
        BbcSignInOrRegisterPage bbcSignInOrRegisterPage;
        public UserSigninSuccessfullyStepDefinitions(IObjectContainer _container)
        {
            _scenarioContext = _container.Resolve<ScenarioContext>();
            bbcHomePage = _container.Resolve<BbcHomePage>();
            bbcSignOutPage = _container.Resolve<BbcSignOutPage>();
            bbcYourAccountPage = _container.Resolve<BbcYourAccountPage>();
            bbcSignInOrRegisterPage = _container.Resolve<BbcSignInOrRegisterPage>();
        }

        [When(@"I click on your account button on the navigation bar")]
        public void ClickOnYourAccountButtonOnTheNavigationBar() => bbcHomePage.clickYourAccountButton();

        [Then(@"(.*) is displayed on the account page")]
        public void ThenIAmOnTheAccountPage(string pageHeader)
        {
            string actualValue = bbcYourAccountPage.getYourAccountHeaderText();
            Assert.AreEqual(pageHeader, actualValue);
        }

        [When(@"I click on Sign out button")]
        public void WhenIClickOnSignOutButton() => bbcYourAccountPage.clickSignOutBtn();
       
        [Then(@"A text is displayed on the Sign out page '(.*)'")]
        public void SorryToSeeYouGoTextIsDisplayed(string pageHeader)
        {
            string actualValue = bbcSignOutPage.getYouHaveSignOutHeaderText();
            Assert.AreEqual(pageHeader, actualValue);
        }

        [When(@"I click on continue button")]
        public void WhenIClickOnContinueButton() => bbcSignOutPage.clickContinueButton();

        [Then(@"(.*) is displayed on the home page")]
        public void ThenIAmBackOnHomePage(string pageHeader)
        {
            string actualValue = bbcHomePage.getWelcomeToBbcHeaderText();
            Assert.AreEqual(pageHeader, actualValue);
        }

        [When(@"I enter email and password")]
        public void WhenIEnterEmailAndPassword()
        {
            bbcSignInOrRegisterPage.enterUserEmail(_scenarioContext.Get<string>("userEmail"));
            bbcSignInOrRegisterPage.enterUserPassword(_scenarioContext.Get<string>("userPassword"));
        }

        [When(@"I click on Sign in button")]
        public void WhenIClickOnSignInButton() => bbcSignInOrRegisterPage.clikSignInBtn();

        [Then(@"I check to verify the presence of the comment Icon is enabled")]
        public void WhenICheckToVerifyThePresenceOfTheCommentIcon()
        {

            if (bbcHomePage.isCommentIconEnabled().Count > 0)
            {
                foreach (var comment in bbcHomePage.isCommentIconEnabled())
                {
                    var isEnabled = comment.Enabled;
                    Assert.IsTrue(comment.Enabled);
                }
            }
            else
            {
                Console.WriteLine("Total count is", bbcHomePage.isCommentIconEnabled().Count);
            }

            //var ist = new List<IWebElement>();
            //ist.Add(bbcHomePage.isCommentIconEnabled()[0]);

            //ist.ForEach(x =>
            //{
            //    Assert.IsTrue(x.Enabled);
            //});

            //bbcHomePage.isCommentIconEnabled().ToList().ForEach(x => { Assert.IsTrue(x.Enabled); });
        }
    }
}