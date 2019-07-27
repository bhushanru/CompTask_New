using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Threading;
using AutoItX3Lib;
using NUnit.Framework;
using System.Linq;
using System.Text;


namespace MarsFramework
{
    internal class ShareSkill
    {

        public ShareSkill()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.Driver, this);
        }

        #region  Initialize Web Elements 
        //Share Skill button
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic green button']")]
        private IWebElement ShareSkillBtn { get; set; }

        //Title
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Write a title to describe the service you provide.']")]
        private IWebElement Title { get; set; }

        //Description
        [FindsBy(How = How.XPath, Using = "//textarea[@placeholder='Please tell us about any hobbies, additional expertise, or anything else you’d like to add.']")]
        private IWebElement Description { get; set; }

        //Category
        [FindsBy(How = How.XPath, Using = "//select[@name='categoryId']")]
        private IWebElement Category { get; set; }

        //Sub-Category
        [FindsBy(How = How.XPath, Using = "//select[@name='subcategoryId']")]
        private IWebElement Subcategory { get; set; }

        //Tags
        [FindsBy(How = How.CssSelector, Using = "div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(4) div.twelve.wide.column div.form-wrapper.field div.ReactTags__tags div.ReactTags__selected div.ReactTags__tagInput > input.ReactTags__tagInputField")]
        private IWebElement Tag1 { get; set; }

        //Service Type
        [FindsBy(How = How.Name, Using = "serviceType")]
        private IWebElement Servicetype { get; set; }

        //Location type
        [FindsBy(How = How.Name, Using = "locationType")]
        private IWebElement Locationtype { get; set; }

        //EndDate
        [FindsBy(How = How.Name, Using = "endDate")]
        private IWebElement Enddate { get; set; }

        //Monday Checkbox
        [FindsBy(How = How.XPath, Using = "//div[3]//div[1]//div[1]//input[1]")]
        private IWebElement MonCheck { get; set; }

        //Monday Start time
        [FindsBy(How = How.XPath, Using = "//div[3]//div[2]//input[1]")]
        private IWebElement MonStart { get; set; }

        //Monday End Time
        [FindsBy(How = How.XPath, Using = "//body//div[3]//div[3]//input[1]")]
        private IWebElement MonEnd { get; set; }

        //Tuesday Checkbox
        [FindsBy(How = How.XPath, Using = "//div[@class='twelve wide column']//div[4]//div[1]//div[1]//input[1]")]
        private IWebElement TuesCheck { get; set; }

        //Tuesday Start time
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[4]//div[2]//input[1]")]
        private IWebElement TuesStart { get; set; }

        //Tuesday End Time
        [FindsBy(How = How.XPath, Using = "//div[4]//div[3]//input[1]")]
        private IWebElement TuesEnd { get; set; }

        //Wednesday Checkbox
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[5]//div[1]//div[1]//input[1]")]
        private IWebElement WedCheck { get; set; }

        //Wednesday Start time
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[5]//div[2]//input[1]")]
        private IWebElement WedStart { get; set; }

        //Wednesday End Time
        [FindsBy(How = How.XPath, Using = "//div[5]//div[3]//input[1]")]
        private IWebElement WedEnd { get; set; }

        //Thursday Checkbox
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[6]//div[1]//div[1]//input[1]")]
        private IWebElement ThursCheck { get; set; }

        //Thursday Start time
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[6]//div[2]//input[1]")]
        private IWebElement ThursStart { get; set; }

        //Thursday End Time
        [FindsBy(How = How.XPath, Using = "//div[6]//div[3]//input[1]")]
        private IWebElement ThursEnd { get; set; }

        //Friday Checkbox
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[7]//div[1]//div[1]//input[1]")]
        private IWebElement FriCheck { get; set; }

        //Friday Start time
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[7]//div[2]//input[1]")]
        private IWebElement FriStart { get; set; }

        //Friday End Time
        [FindsBy(How = How.XPath, Using = "//div[@class='tooltip-target ui grid']//div[7]//div[3]//input[1]")]
        private IWebElement FriEnd { get; set; }

        //Select Skill Trade
        [FindsBy(How = How.Name, Using = "skillTrades")]
        private IWebElement SkillTrade { get; set; }

        //Select Skill Exchange
        [FindsBy(How = How.CssSelector, Using = "div.ui.container:nth-child(3) div.listing form.ui.form div.tooltip-target.ui.grid:nth-child(8) div.twelve.wide.column:nth-child(4) div.field div.form-wrapper div.ReactTags__tags div.ReactTags__selected div.ReactTags__tagInput > input.ReactTags__tagInputField")]
        private IWebElement SkillExchange { get; set; }

        //Click Upload Icon
        [FindsBy(How = How.XPath, Using = "//I[@class='huge plus circle icon padding-25']")]
        private IWebElement Upload { get; set; }


        //Selct Skill Active
        [FindsBy(How = How.Name, Using = "isActive")]
        private IWebElement SkillActive { get; set; }

        //Select Save
        [FindsBy(How = How.XPath, Using = "//input[@class='ui teal button']")]
        private IWebElement Savebtn { get; set; }

        //Select ManageListing MEnu
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Manage Listings')]")]
        private IWebElement ManageListing { get; set; }

        
        //Actual Value1
        [FindsBy(How = How.XPath, Using = "//td[contains(text(),'Software Tester 7')]")]
        private IWebElement ActualValue1 { get; set; }



        #endregion

        internal void AddShareSkill(IWebDriver Driver)
        {

            //Populate the Excel sheet
            Global.GlobalDefinitions.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "ShareSkillTestData");
            Thread.Sleep(1000);

            //Click Share Skill button
            ShareSkillBtn.Click();
            Thread.Sleep(5000);

            //Title Input
            Title.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Description Input
            Description.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select Category
            var selectElement1 = new SelectElement(Category);
            selectElement1.SelectByValue("6");
            Console.WriteLine("Category selcted");

            //Select Sub-Catergory

            var selectElement2 = new SelectElement(Subcategory);
            selectElement2.SelectByText("QA");
            Console.WriteLine("Sub-Category selcted");

            //Select Tags
            Tag1.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "Tag1"));
            Tag1.SendKeys(Keys.Enter);

            Console.WriteLine("Enter clicked");

            //Select Service Type
            Servicetype.Click();

            //Select Location Type
            Locationtype.Click();

            //Select End date
            Enddate.SendKeys("29-07-2019");

            //Input for the whole week
            //Monday time
            MonCheck.Click();
            MonStart.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "MonStart"));
            MonEnd.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "MonEnd"));

            //Tuesday time
            TuesCheck.Click();

            TuesStart.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "TuesStart"));
            TuesEnd.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "TuesEnd"));

            //Wednesday time
            WedCheck.Click();
            WedStart.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "WedStart"));
            WedEnd.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "WedEnd"));

            //Thursday time
            ThursCheck.Click();
            ThursStart.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "ThursStart"));
            ThursEnd.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "ThursEnd"));

            //Friday time
            FriCheck.Click();
            FriStart.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "FriStart"));
            FriEnd.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "FriEnd"));

            //Select Skill trade
            SkillTrade.Click();

            //Select Skill Exchange
            SkillExchange.SendKeys(Global.GlobalDefinitions.ExcelLib.ReadData(2, "SkillExchange"));
            SkillExchange.SendKeys(Keys.Enter);

            ////Upload Work Sample Upload click
            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver;
            js1.ExecuteScript("arguments[0].click();", Upload);
            Thread.Sleep(5000);

            AutoItX3 autoIt = new AutoItX3();
            Thread.Sleep(5000);
            autoIt.WinActivate("Open");
            autoIt.Send(@"C:\Users\Bhushan\Desktop\Updated - Mars(QA)-CompetitionTask.pdf");
            Thread.Sleep(4000);
            autoIt.Send("{ENTER}");

            //Select Active
            SkillActive.Click();

            //Click Save
            Savebtn.Click();
            Thread.Sleep(5000);

            Base.test.Log(LogStatus.Info, "Skill added successfully");
            
            //Verification
            Thread.Sleep(4000);
            string ExpectedResult1 = Global.GlobalDefinitions.ExcelLib.ReadData(2, "Title");
            string ActualResult1 = ActualValue1.Text;

            if (ActualResult1 == ExpectedResult1)
            {
                Console.WriteLine("Test Pass: Skill Added");
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
                Console.WriteLine("Test Fail: Skill Not Added");
            }

            //try
            //{

            //    Assert.IsTrue(Driver.FindElement(By.XPath("//tr[1]//td[3]")).Displayed);
            //    Console.WriteLine("Test Pass: Skill listing Added");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Test Fail: Skill listing not present");
            //}
        }
    }
}