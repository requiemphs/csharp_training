using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            applicationManager.Group.CheckGroupCreated();

            GroupData newData = new GroupData("22.09");
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = applicationManager.Group.GetGroupList();
            applicationManager.Group.Modify(0, newData);
            List<GroupData> newGroups = applicationManager.Group.GetGroupList();
            Assert.AreNotEqual(oldGroups, newGroups);
        }
    }
}
