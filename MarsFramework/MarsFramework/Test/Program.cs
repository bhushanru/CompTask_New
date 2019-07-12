using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsFramework.Global;
using MarsFramework.Pages;
using OpenQA.Selenium.Chrome;

namespace MarsFramework
{
    public class Program
    {
        [TestFixture]
        [Category("Sprint1")]
        class Tenant : Global.Base
        {

            
            [Test]
            public void AddSkill()
            {

                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Add a skill");

                //steps to Add a share skill
                ShareSkill obj2 = new ShareSkill();
                obj2.AddShareSkill();

            }

            [Test]
            public void EditSkill()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Edit a skill");
                //Edit listing
                ManageListing obj3 = new ManageListing();
                obj3.EditListing();

            }

            [Test]
            public void DelSkill()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Delete a skill");
                //Delete a listing
                ManageListing obj3 = new ManageListing();
                obj3.DeleteListing();

            }

           
        }
    }
}