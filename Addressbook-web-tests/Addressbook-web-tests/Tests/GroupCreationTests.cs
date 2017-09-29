using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("FullName");
            group.Header = "@@@";
            group.Footer = "666";

            List<GroupData> oldGroups = applicationManager.Group.GetGroupList();

            applicationManager.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Group.GetGroupCount());

            List<GroupData> newGroups =  applicationManager.Group.GetGroupList();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = applicationManager.Group.GetGroupList();
            applicationManager.Group.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Group.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";
            List<GroupData> oldGroups = applicationManager.Group.GetGroupList();
            applicationManager.Group.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, applicationManager.Group.GetGroupCount());
            List<GroupData> newGroups = applicationManager.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
