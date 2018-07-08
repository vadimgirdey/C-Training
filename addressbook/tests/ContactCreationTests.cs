using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        
        [Test]

        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("firstname", "lastName");

            List<ContactData> oldContacts = app.Contact.GetContactsList();

            app.Contact.Create(contact);

            List<ContactData> newContacts = app.Contact.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
