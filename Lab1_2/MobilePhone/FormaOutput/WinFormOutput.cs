using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutputInfo;
using System.Windows.Forms;

namespace FormaOutput
{
    public class WinFormOutput : IOutput
    {
        public WinFormOutput(RichTextBox aCanvas)
        {
            Canvas = aCanvas;
        }

        private RichTextBox canvas = null;
        public RichTextBox Canvas { get { return canvas; }
            set { canvas = value; } }
        public void Write(string text)
        {
            Canvas?.AppendText(text);
        }

        public void WriteLine(string text)
        {
            Canvas?.AppendText(text+"\r\n");
        }
    }
}
