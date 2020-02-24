using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using SeleniumWebdriver.ComponentHelper;
using SeleniumWebdriver.Configuration;
using SeleniumWebdriver.CustomException;
using SeleniumWebdriver.Reports;
using SeleniumWebdriver.Settings;
using TechTalk.SpecFlow;

namespace SeleniumWebdriver.BaseClasses
{
    [TestClass]
    
    public class BaseClass 
    {
        private static readonly ILog Logger = Log4NetHelper.GetXmlLogger(typeof (BaseClass));

        private static ChromeOptions GetChromeOptions()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("start-maximized");
            //option.AddArgument("--headless");
            //option.AddExtension(@"C:\Users\rahul.rathore\Desktop\Cucumber\extension_3_0_12.crx");
            Logger.Info(" Using Chrome Options ");
            return option;
        }

        private static InternetExplorerOptions GetIEOptions()
        {
            InternetExplorerOptions options = new InternetExplorerOptions();
            options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
            options.EnsureCleanSession = true;
            options.ElementScrollBehavior = InternetExplorerElementScrollBehavior.Bottom;
            Logger.Info(" Using Internet Explorer Options ");
            return options;
        }

        
        //private static FirefoxDriver GetFirefoxDriver()
        //{
        //    FirefoxOptions options = new FirefoxOptions();
        //    FirefoxDriver driver = new FirefoxDriver(GetFirefoxptions());
        ////    return driver;
        //}

        private static ChromeDriver GetChromeDriver()
        {
            ChromeDriver driver = new ChromeDriver(GetChromeOptions());
            return driver;
        }

        private static InternetExplorerDriver GetIEDriver()
        {
            InternetExplorerDriver driver = new InternetExplorerDriver(GetIEOptions());
            return driver;
        }
      

        [AssemblyInitialize]
        public static void InitWebdriver(TestContext tc)
        {
            ObjectRepository.Config = new AppConfigReader();
            Reporter.GetReportManager();
            Reporter.AddTestCaseMetadataToHtmlReport(tc);
            switch (ObjectRepository.Config.GetBrowser())
            {
                case BrowserType.Chrome:
                    ObjectRepository.Driver = GetChromeDriver();
                    Logger.Info(" Using Chrome Driver  ");
                    break;

                case BrowserType.IExplorer:
                    ObjectRepository.Driver = GetIEDriver();
                    Logger.Info(" Using Internet Explorer Driver  ");
                    break;

              //  case BrowserType.PhantomJs:
              //      ObjectRepository.Driver = GetPhantomJsDriver();
              //      Logger.Info(" Using PhantomJs Driver  ");
               //     break;

                default:
                    throw new NoSutiableDriverFound("Driver Not Found : " + ObjectRepository.Config.GetBrowser().ToString()); 
            }
            ObjectRepository.Driver.Manage()
                .Timeouts().PageLoad = TimeSpan.FromSeconds(ObjectRepository.Config.GetPageLoadTimeOut());
            ObjectRepository.Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(ObjectRepository.Config.GetElementLoadTimeOut());
            BrowserHelper.BrowserMaximize();
        }


        [AssemblyCleanup]
        //[AfterScenario()]
        public static void TearDown()
        {
            if (ObjectRepository.Driver != null)
            {
               ObjectRepository.Driver.Close();
               ObjectRepository.Driver.Quit();
            }
            Logger.Info(" Stopping the Driver  ");
        }
    }
}
