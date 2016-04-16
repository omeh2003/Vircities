using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.IO;

namespace Vircities
{
    class Util
    {
        static RemoteWebDriver _WebDriver;
        private static ChromeOptions chromeOptions;
        private static string defaultDataFolder;

        public static RemoteWebDriver WebDriver
            {
               get
                 {
                if (_WebDriver == null)
                {
                     chromeOptions = new ChromeOptions();
                     defaultDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\..\Local\Google\Chrome\User Data\Default";

                    _WebDriver = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);
                    _WebDriver.Manage().Window.Maximize();
                  

                }
     
                    return _WebDriver;
                }
            }
     
            public static void OpenURL(string URL)
            {
                WebDriver.Navigate().GoToUrl(URL);
            }
     
            public static IWebElement FindWebElement(WebItem webItem)
            {
                if (webItem.ID != "")
                    return WebDriver.FindElementById(webItem.ID);
     
                if (webItem.ClassName != "")
                    return WebDriver.FindElementByClassName(webItem.ClassName);
     
                if (webItem.XPathQuery != "")
                    return WebDriver.FindElementByXPath(webItem.XPathQuery);

            if (webItem.LinkText != "")
                return WebDriver.FindElementByLinkText(webItem.LinkText);


                return null;
            }
     
            public static void Delay(int Seconds = 10)
            {
                System.Threading.Thread.Sleep(Seconds* 1000);
            }

    }

    public class WebItem
         {
             public string ID;
             public string ClassName;
             public string XPathQuery;
            public string LinkText;
      
             public WebItem(string ID, string ClassName, string XPathQuery, string LinkText)
             {
                 this.ID = ID;
                this.ClassName = ClassName;
                this.XPathQuery = XPathQuery;
            this.LinkText = LinkText;

            }
     
            public void Click()
            {
                Util.FindWebElement(this).Click();
            }
     
            public void SetValue(string Value)
            {
                Util.FindWebElement(this).SendKeys(Value);
            }


    }

    public class LoginAction
         {
             public static void DoLogin()
            {
            Page.LoginWebItems.LoginLink.Click();
           // Util.Delay(2);
            Page.LoginWebItems.UserNameTextBox.SetValue("******");
            Page.LoginWebItems.PasswordTextBox.SetValue("******");
            Page.LoginWebItems.LoginButton.Click();
           Util.Delay(5);
            }
        }
}
