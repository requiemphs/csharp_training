using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            applicationManager.Group.CheckGroupCreated();

            List<GroupData> oldGroups = applicationManager.Group.GetGroupList();

            applicationManager.Group.Remove(0);
            Assert.AreEqual(oldGroups.Count - 1, applicationManager.Group.GetGroupCount());

            List<GroupData> newGroups = applicationManager.Group.GetGroupList();
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
