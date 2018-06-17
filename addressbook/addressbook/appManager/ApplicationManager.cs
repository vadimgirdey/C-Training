using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressBookTests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        protected string baseURL;

        public LoginHelper loginHelper;
        public NavigationHelper navigationHelper;
        public GroupHelper groupHelper;
        public ContactHelper contactHelper;

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
            contactHelper = new ContactHelper(this);
        }

        public void Stop() {

            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }

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

        public ContactHelper Contact {
            get {
                return contactHelper;
            }
        }

        public void LogOut (){

            driver.FindElement(By.LinkText("Logout")).Click();

        }

    }

   
}
