using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager applicationManager;

        [SetUp]
        public void SetupTest()
        {
            applicationManager = new ApplicationManager();
            applicationManager.Navigator.GoToHomePage();
            applicationManager.Auth.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            applicationManager.Auth.LogOut();
            applicationManager.Stop(); 
        }

    }
}
