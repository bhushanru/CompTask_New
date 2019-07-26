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
            var title2 = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            if (title1 == title2)
            {
                Console.WriteLine("Test1 passed : title edited successfully");
                Console.WriteLine("Test Pass: Skill Added");
                // Screenshot
                String img = Global.GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "Report");
                Base.test.Log(LogStatus.Info, "Image example: " + img);
                // end test. (Reports)
                Base.extent.EndTest(Base.test);
                // calling Flush writes everything to the log file (Reports)
                Base.extent.Flush();
                // Close the driver :)            
                //GlobalDefinitions.driver.Close();
                
            }
            else
            {
                Console.WriteLine("Test1 failed : Title not edited");
            }
            //try
            //{
            //    Assert.AreEqual("Industry Connect Software Tester", ManageListTitle.Text);
            //    Console.WriteLine("Test Pass: Skill listing edited");
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine("Test Fail: Skill listing NOT Edited");
            //}


        }




        public void DeleteListing(IWebDriver Driver)
        {
            //Click Manage Listings Menu

            ManageListingsMenu.Click();
            Thread.Sleep(5000);

            IJavaScriptExecutor js3 = (IJavaScriptExecutor)Driver;
            js3.ExecuteScript("arguments[0].click();", ManageListTitle);

            //try
            //{
            //    Assert.IsTrue(ManageListTitle.Displayed);
            //    //Click Delete Icon
            //    IJavaScriptExecutor js2 = (IJavaScriptExecutor)Driver;
            //    js2.ExecuteScript("arguments[0].click();", Delelement);

            //    //click "Yes" in delete pop up
            //    DelYes.Click();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Title cannot be found");
            //}

            //Verfication
            string ExpResult3 = "Software Tester has been deleted";
            Thread.Sleep(2000);
            string ActualResult3 = ActResult3.Text;

            if (ExpResult3 == ActualResult3)
            {
                Console.WriteLine("Test 3 Pass : Record deleted successully");

                // Screenshot
                String img = Global.GlobalDefinitions.SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.Driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
                Base.test.Log(LogStatus.Info, "Image example: " + img);
                // end test. (Reports)
                Base.extent.EndTest(Base.test);
                // calling Flush writes everything to the log file (Reports)
                Base.extent.Flush();
                // Close the driver :)            
                //GlobalDefinitions.driver.Close();
            }
            else
            {
                Console.WriteLine("Test 3 Fail: Record not deleted");
            }
            //        try
            //        {

            //            Assert.AreEqual("Software tester 7 has been deleted",ActResult3.Text);
            //            Console.WriteLine("Test Fail: Skill listing still present");
            //        }
            //        catch(Exception e)
            //        {
            //            Console.WriteLine("Test Pass: Skill listing Deleted");
            //        }
            //    }
            //}
        }
    }
}
