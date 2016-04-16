using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vircities
{
    class Page
    {
        public static class LoginWebItems
         {
             public static WebItem LoginLink
             {
                 get
                 {
                     return new WebItem("", "", "/html/body/div[1]/div[2]/a","");
                 }
             }
     
            public static WebItem UserNameTextBox
            {
                get
                {
                    return new WebItem("UserUsername", "", "","");
                }
            }
     
            public static WebItem PasswordTextBox
            {
                get
                {
                    return new WebItem("UserPassword", "", "","");
                }
            }
     
            public static WebItem LoginButton
            {
                get
                {
                    return new WebItem("", "", @"//button[@type='submit']","");
                }
            }
       }

        public static class WebItems
        {


            public static string InventoreItems
            {
                get
                {
                    return Util.WebDriver.FindElementByXPath(@"//div[@id='profile']/div[2]/div/div/div[2]/div").Text;
                }
            }

        }

        public class PagesActions
         {
             public static void OpenHomePage()
             {
                 Util.OpenURL("http://vircities.com/");
             }

            public static void OpenInventory()
            {
                var link = new WebItem("", "", @"//div[@id='short-info']/div/div/div/div/div[2]/img", "");
                link.Click();

            }
         }


    }
}
