using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.IO;

namespace Vircities
{
    [TestClass]
    public class UnitTest1
    {
 

        [TestMethod]
        public void TestMethod1()
        {
            Page.PagesActions.OpenHomePage();
            LoginAction.DoLogin();
            Page.PagesActions.OpenInventory();
            Util.Delay(5);
            
            Assert.AreEqual(Page.WebItems.InventoreItems, "РЮКЗАК (0 / 20)");
            Util.WebDriver.Close();


        }
    }
}
