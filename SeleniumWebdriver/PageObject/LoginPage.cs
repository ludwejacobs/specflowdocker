using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SeleniumWebdriver.BaseClasses;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Settings;
using System;

namespace SeleniumWebdriver
{
    public class LoginPage : PageBase
    {
        private IWebDriver driver;

        [FindsBy(How = How.ClassName, Using = "login_logo")]
        [CacheLookup]
        private IWebElement Header;


        [FindsBy(How = How.Id, Using = "user-name")]
        private IWebElement UsernameTextBox;
        //private By UsernameTextBox = By.Id("user-name");



        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement PassTextBox;
        //private By PassTextBox = By.Id("password");


        [FindsBy(How = How.XPath, Using = "//*[@id='login_button_container']/div/form/input[3]")]
        [CacheLookup]
        private IWebElement LoginButton;





        public LoginPage(IWebDriver _driver) : base(_driver)
        {
            this.driver = _driver;
        }


        public void HeaderIsPresent()
        {
            Assert.AreEqual(GenericHelper.IsElemetPresent(By.ClassName("login_logo")), GenericHelper.IsElemetPresent(By.ClassName("login_logo")));
        }

        public void Username(string username)
        {
            UsernameTextBox.SendKeys(username);
        }
        public void Password(string password)
        {
            PassTextBox.SendKeys(password);

        }

        public void ClickLoginButton()
        {
            LoginButton.Click();
        }



        public void ErrorMessage()
        {
            GenericHelper.WaitForWebElementInPage(By.CssSelector("button[class='error-button']:contains "), TimeSpan.FromSeconds(30));

        }

    }

}
