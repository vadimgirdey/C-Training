using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressBookTests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        //private StringBuilder verificationErrors;
        protected string baseURL;

        public LoginHelper loginHelper;
        public NavigationHelper navigationHelper;
        public GroupHelper groupHelper;

        public IWebDriver Driver { 
            get {

                return driver;
            } 
        }

        public ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this, baseURL);
            groupHelper = new GroupHelper(this);
        }

        public void Stop() {

            //try
            //{
                driver.Quit();
            //}
            ////catch (Exception)
            //{
            //    // Ignore errors if unable to close the browser
            //}
            //Assert.AreEqual("", verificationErrors.ToString());

        }

        public LoginHelper Auth {
            get {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }


        public void LogOut (){

            driver.FindElement(By.LinkText("Logout")).Click();

        }

    }

   
}
