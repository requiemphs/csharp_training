using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{

    [TestFixture]
    class ContactModificationTests : ContactTestBase
    {
        [Test]
                public void ContactModificationTest()
        {
            applicationManager.Contact.CheckContactCreated();
            ContactData newData = new ContactData("Миньон", "newData");

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            applicationManager.Contact.Modify(oldData, newData);
            Assert.AreEqual(oldContacts.Count, applicationManager.Contact.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                }
            }
        }
    }
}
