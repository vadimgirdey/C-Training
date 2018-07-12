using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
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
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contact.GetContactsList();

            app.Navigator.GoToContactPage();
            app.Contact
                              .RemoveContact(0)
                              .IsAlertPresent();
            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactsCount());

            List<ContactData> newContacts = app.Contact.GetContactsList();

            oldContacts.Sort();
            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);
            
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreEqual(contact.Id, toBeRemoved.Id);
            }

        }
    }
}