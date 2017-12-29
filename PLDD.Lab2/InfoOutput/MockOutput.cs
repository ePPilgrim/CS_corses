using System.Text;

namespace PLDD.Lab2.OutputInfo
{
    public class MockOutput : IOutput
    {
        private StringBuilder Output = new StringBuilder();

        public void Write(string text) {
            Output.Append(text);
        }

        public void WriteLine(string text) {
            Output.AppendLine(text);
        }

        public override string ToString() {
            return Output.ToString();
        }

        public void Clear() {
            Output = new StringBuilder();
        }

    }
}
