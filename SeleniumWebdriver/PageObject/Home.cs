
//using OpenQA.Selenium;
//using OpenQA.Selenium.Support.PageObjects;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using SeleniumWebdriver.BaseClasses;
//using SeleniumWebdriver.ComponentHelper;

//namespace SeleniumWebdriver
//{
//    public class HomePage : PageBase
//    {
   
//        private readonly IWebDriver _driver;
//        #region WebElement

//        [FindsBy(How = How.ClassName, Using = "product_sort_container")]
//        private IWebElement product_sort_container;


//        #endregion
//        public HomePage(IWebDriver _driver) : base(_driver)
//        {
//            this._driver = _driver;
//        }
//        #region #region Action

//        public void SelectFromSeverity(string value)
//        {
//            ComboBoxHelper.SelectElement(product_sort_container, value);
//        }
//        #endregion
//    }
//}
