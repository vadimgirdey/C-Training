
using NUnit.Framework;


namespace WebAddressBookTests
{

    [SetUpFixture]

    public class TestSuitFixture
    {

        [SetUp]
        public void InitApplicationManager()
        {
            ApplicationManager app = ApplicationManager.GetInstance();
        }
    }
}
