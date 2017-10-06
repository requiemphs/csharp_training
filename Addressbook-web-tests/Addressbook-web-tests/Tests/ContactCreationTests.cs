using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 3; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {

                    Address = GenerateRandomString(100),
                    Home = GenerateRandomString(9),
                    Mobile = GenerateRandomString(9),
                    Email = GenerateRandomString(9)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = applicationManager.Contact.GetContactList();

            applicationManager.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, applicationManager.Contact.GetContactCount());

            List<ContactData> newContacts = applicationManager.Contact.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }




    }
}
