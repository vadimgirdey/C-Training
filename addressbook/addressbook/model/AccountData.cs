using System;
namespace WebAddressBookTests
{
    public class AccountData
    {
        public AccountData()
        { }
            private string username;
            private string password;

            public AccountData(string username, string password)
            {
                this.username = username;
                this.password = password;
            }

            public string Username {
                get{
                return username;
                }
                set {
                username = value;
                }
            }
            public string Password
        {
            get
            {
                return password;
                }
            set
            {
                    password = value;
            }

        }
    }
}
