using NUnit.Framework;



namespace WebAddressBookTests
{
    [TestFixture]

    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("newName");
            newData.Header = "newHeader";
            newData.Footer = "newFooter";

            applicationManager.Groups.Modify(1, newData);
        }
    }
}
