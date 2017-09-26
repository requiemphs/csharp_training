using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        [Test]
                public void ContactModificationTest()
        {
            applicationManager.Contact.CheckContactCreated();
            ContactData newData = new ContactData("Миньон", "newData");

            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();
            
            applicationManager.Contact.Modify(0,newData);

            List<ContactData> newContacts = applicationManager.Contact.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
