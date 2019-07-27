using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MarsFramework.Global;
using OpenQA.Selenium.Support.PageObjects;
using RelevantCodes.ExtentReports;

namespace MarsFramework.Pages
{
    class ManageListing
    {
        public ManageListing()
        {
            PageFactory.InitElements(GlobalDefinitions.Driver, this);
        }

        #region  Initialize Web Elements 
        //Defining IWebElements
        //ManageListing Menu
        [FindsBy(How = How.CssSelector, Using = "div:nth-child(1) div:nth-child(1) section.nav-secondary:nth-child(2) div.ui.eight.item.menu > a.item:nth-child(3)")]
        public IWebElement ManageListingsMenu { get; set; }

        //Edit Icon Element
        [FindsBy(How = How.CssSelector, Using = "table.ui.striped.table:nth-child(1) tbody:nth-child(2) tr:nth-child(1) td.one.wide:nth-child(8) > i.outline.write.icon")]
        private IWebElement Element { get; set; }

        //Title
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Write a title to describe the service you provide.']")]
        private IWebElement Title { get; set; }

        //Save Button
        [FindsBy(How = How.XPath, Using = "//input[@class='ui teal button']")]
        private IWebElement SaveBtn { get; set; }

        //Delete Icon
        [FindsBy(How = How.CssSelector, Using = "table.ui.striped.table:nth-child(1) tbody:nth-child(2) tr:nth-child(1) td.one.wide:nth-child(8) > i.remove.icon")]
        private IWebElement Delelement { get; set; }

        //Delete Icon
        [FindsBy(How = How.XPath, Using = "//button[@class='ui icon positive right labeled button']")]
        private IWebElement DelYes { get; set; }

        //ManageListingTitle
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Software Tester 7')]")]
        private IWebElement ManageListTitle { get; set; }

        //ActualResult3
        [FindsBy(How = How.XPath, Using = "//div[@class='ns-box-inner']")]
        private IWebElement ActResult3 { get; set; }
        #endregion


        //Edit Method
        public void EditListing(IWebDriver Driver)
        {

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "EditShareSkillTestData");

            //Click Manage Listings Menu
            ManageListingsMenu.Click();
            Thread.Sleep(7000);

            //Click Edit Icon
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver;
            js1.ExecuteScript("arguments[0].click();", Element);
            Thread.Sleep(5000);

            //Change Title
            string title1 = Title.Text;
            Title.Clear();
            Title.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title"));


            //Click Savebutton
            SaveBtn.Click();
            Thread.Sleep(5000);

            //Verification   

            ManageListingsMenu.Click();
            Thread.Sleep(7000);
            //Click Edit icon
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver;
            js2.ExecuteScript("arguments[0].click();", Element);
            Thread.Sleep(5000);
            try
            {
                       
            Assert.AreEqual("Industry Connect Software Tester", Title.Text);

            Console.WriteLine("Test1 passed : title edited successfully");
            //Screenshot
            String img = Global.GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "Report");
            Base.test.Log(LogStatus.Info, "Image example: " + img);
            //end test. (Reports)
            Base.extent.EndTest(Base.test);
            //calling Flush writes everything to the log file(Reports)
            Base.extent.Flush();
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Test Fail: Skill listing NOT Edited");
            }
                       
            }


        //Delete Method

        public void DeleteListing(IWebDriver Driver)
        {
            //Click Manage Listings Menu

            ManageListingsMenu.Click();
            Thread.Sleep(5000);

            //Identify Title of the record to be deleted
            IJavaScriptExecutor js3 = (IJavaScriptExecutor)Driver;
            js3.ExecuteScript("arguments[0].click();", ManageListTitle);

            //Click Delete icon
            IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver;
            js2.ExecuteScript("arguments[0].click();", Delelement);

            //click "Yes" in delete pop up
            DelYes.Click();

            //Verfication
            try
            {
            Thread.Sleep(5000);
            Assert.IsTrue(ActResult3.Displayed);
            Console.WriteLine("Test 3 Pass : Record deleted successfully");

            // Screenshot
            String img = Global.GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            Base.test.Log(LogStatus.Info, "Image example: " + img);
            // end test. (Reports)
            Base.extent.EndTest(Base.test);
            // calling Flush writes everything to the log file (Reports)
            Base.extent.Flush();
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Test 3 Pass : Record NOT deleted");
            }
            
        }
    }
}
