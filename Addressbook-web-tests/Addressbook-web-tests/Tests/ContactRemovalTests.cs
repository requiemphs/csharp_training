using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Contact.CheckContactCreated();

            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();

            applicationManager.Contact.Remove(0);

            List<ContactData> newContacts = applicationManager.Contact.GetContactList();

            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
