using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificatorTests : AuthTestBase
    {
        [SetUp]
        public void VerificationTest()
        {
            if (!app.Contact.IsPresent())
            {
                ContactData contact = new ContactData("name", "lastName");

                app.Contact.Create(contact);
                app.Navigator.GoToHomePage();

                
            }
        }
        [Test]
        public void ContactModificatorTest()
        {
            ContactData contact = new ContactData("newFirstName", "newLastName");
            List<ContactData> oldContacts = app.Contact.GetContactsList();

            app.Contact.Modify(0, contact);

            List<ContactData> newContacts = app.Contact.GetContactsList();
            oldContacts[0].firstName = contact.firstName;
            oldContacts[0].lastName = contact.lastName;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
