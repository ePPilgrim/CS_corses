using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public class Keyboard: PhoneComponent
    {
        public Keyboard(int aWidth, int aHeight, int aNumOfKeys) : 
            base(aWidth, aHeight)
        { 
            NumOfKeys = aNumOfKeys;
        }

        private int numOfKeys;
        public int NumOfKeys
        {
            get { return numOfKeys; }
            set { numOfKeys = value < 0 ? 0 : value; }
        }

        public override string ToString()
        {
            string str = "Keyboard:\n";
            str += NumOfKeys == 0 ? "Totaly virtual keyboard;" : $"Number of Keys is {NumOfKeys};" + '\n';
            return base.GetClassInfo(str);
        }
    }

}
