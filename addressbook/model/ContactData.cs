using System;
namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string fName { get; set; }
        public string lName { get; set; }
        public string Id { get; set; }

        public ContactData (string firstName, string lastName, string id)
        {
            fName = firstName;
            lName = lastName;
            Id = id; 
        }
        public ContactData(string firstName, string lastName)
        {
            fName = firstName;
            lName = lastName;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return fName == other.fName
                && lName == other.lName;
        }
        public override int GetHashCode()
        {
            return lName.GetHashCode();
        }
        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return fName.CompareTo(other.fName);
        }
    }
}
