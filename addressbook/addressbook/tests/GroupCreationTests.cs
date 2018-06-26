using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            
            GroupData group = new GroupData("name");
            group.Header = "Header";
            group.Footer = "Footer";

            app.Groups.Create(group);

            app.Navigator.GoToHomePage();

        } 
    
 

        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);

            app.Navigator.GoToHomePage();
        }
    }
}
  