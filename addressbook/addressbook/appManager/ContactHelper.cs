using OpenQA.Selenium;
namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper (ApplicationManager manager) : base(manager)
        {
        }


        public ContactHelper FillContact(string firstName, string lastName)
        {
            ContactData fillContact = new ContactData(firstName, lastName);
            return this;
        }

        public ContactHelper GoToAddNewPage()
        {
            driver.FindElement(By.XPath("//a[text()= 'add new']")).Click();
            return this;
        }
    }
}
