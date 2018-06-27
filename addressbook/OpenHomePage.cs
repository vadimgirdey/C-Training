using System;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class OpenHomePage
    {
        public OpenHomePage(IWebDriver driver, string baseURL)
        {
          driver.Navigate().GoToUrl(baseURL + "addressbook/index.php");
        }
    }
}
