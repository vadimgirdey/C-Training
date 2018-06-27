﻿using NUnit.Framework;


namespace WebAddressBookTests
{
    public class AuthTestBase : TestBase
    {
        
        [SetUp]

        public void SetupLogin()
        {
            app.Auth.Login(new AccountData("admin", "secret"));

        }
    }
}
