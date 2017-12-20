using OutputInfo;
using System.Windows.Forms;

namespace FormaOutput
{
    public class WinFormOutput : IOutput
    {
        private RichTextBox vCanvas = null;
        public RichTextBox Canvas {
            get { return vCanvas; }
            set { vCanvas = value; }
        }

        public WinFormOutput(RichTextBox canvas) {
            Canvas = canvas;
        }

        public void Write(string text) {
            Canvas?.AppendText(text);
        }

        public void WriteLine(string text) {
            Canvas?.AppendText(text+"\r\n");
        }
    }
}
