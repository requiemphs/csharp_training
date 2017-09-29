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
            GroupData oldData = oldGroups[0];

            applicationManager.Group.Modify(0, newData);
            Assert.AreEqual(oldGroups.Count, applicationManager.Group.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Group.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }
    }
}
