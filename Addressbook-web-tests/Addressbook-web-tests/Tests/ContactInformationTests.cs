using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationFromTable()
        {
                ContactData fromTable = applicationManager.Contact.GetContactInformationFromTable(0);
                ContactData fromForm = applicationManager.Contact.GetContactInformationFromEditForm(0);

            //verifications
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
        }

        [Test]
        public void TestContactInformationFromDetails()
        {
            ContactData fromDetail = applicationManager.Contact.GetContactInformationFromDetails();
            ContactData fromForm = applicationManager.Contact.GetContactInformationFromEditForm(0);

            //verifications

            Assert.AreEqual(fromDetail.AllInformation, fromForm.AllInformation);

        }
    }
}
