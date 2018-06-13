using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            
            GroupData group = new GroupData("name");
            group.Header = "Header";
            group.Footer = "Footer";

            applicationManager.Groups.Create(group);

            applicationManager.Navigator.GoToHomePage();
            applicationManager.LogOut();
        }

        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            applicationManager.Groups.Create(group);

            applicationManager.Navigator.GoToHomePage();
            applicationManager.LogOut();
        }
    }
}
