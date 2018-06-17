using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            applicationManager.Navigator.GoToContactPage();
            applicationManager.Contact
                              .SelectContact("4")
                              .RemoveContact()
                              .IsAlertPresent();
        }
    }
}