using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.StepDefinition
{
    [Binding]
    public sealed class TestFeature
    {
        LoginPage loginPage = new LoginPage(ObjectRepository.Driver);

        [Given(@"the LoginPage is open")]
        public void GivenTheLoginPageIsOpen()
        {
            NavigationHelper.NavigateToUrl("https://www.saucedemo.com/");
        }

        [Given(@"the user fills their (.*)")]
        public void GivenTheUserFillsTheirUsername(string username)
        {
            loginPage.Username(username);
        }


        [Given(@"the page ""(.*)"" message is present")]
        public void GivenThePageMessageIsPresent(string title)
        {
            loginPage.HeaderIsPresent();

        }


        [When(@"the user clicks the login button")]
        public void WhenTheUserClicksTheLoginButton()
        {
            loginPage.ClickLoginButton();
        }

        [Then(@"the ""(.*)"" message is displayed")]
        public void ThenTheMessageIsDisplayed()
        {
            loginPage.ErrorMessage();
        }


    }
}
