using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutputInfo
{
    public class MockOutput : IOutput
    {
        private StringBuilder output = new StringBuilder();

        public void Write(string text)
        {
            output.Append(text);
        }

        public void WriteLine(string text)
        {
            output.AppendLine(text);
        }

        public override string ToString()
        {
            return output.ToString();
        }

        public void Clear()
        {
            output = new StringBuilder();
        }

    }
}
