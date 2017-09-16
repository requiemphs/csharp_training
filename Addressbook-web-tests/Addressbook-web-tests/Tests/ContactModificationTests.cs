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
            ContactData newData = new ContactData("Миньон", "newData");
            applicationManager.Contact.Modify(1,newData);
        }
    }
}
