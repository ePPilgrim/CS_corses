using OutputInfo;

namespace MobilePhonePlugin
{
    public class PhoneSpeaker : IPlayback
    {
        private IOutput Output = null;

        public PhoneSpeaker(IOutput output) {
            Output = output;
        }
        
        public void Play(object data) {
            Output.WriteLine($"{ToString()} play sound.");
        }

        public override string ToString() {
            return "Phone Speaker";
        }
    }
}
