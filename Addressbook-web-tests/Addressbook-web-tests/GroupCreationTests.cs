using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("!!!");
            group.Header = "@@@";
            group.Footer = "666";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            LogOut();
        }
     }
}
