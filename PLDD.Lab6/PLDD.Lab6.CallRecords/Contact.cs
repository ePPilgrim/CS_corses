using System.Collections.Generic;

namespace PLDD.Lab6.CallRecords
{
    public class Contact
    {
        public string Name { get; set; } = null;

        private List<int> vPhoneNumbers = null;
        public List<int> PhoneNumbers {
            get {
                if( vPhoneNumbers == null ) { vPhoneNumbers = new List<int>();  }
                return vPhoneNumbers;
            }
        }

        public Contact(string userName = "") { Name = userName; }
    }
}
