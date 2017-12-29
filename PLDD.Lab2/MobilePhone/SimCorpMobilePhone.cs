using PLDD.Lab2.MobilePhonePlugin;
using PLDD.Lab2.OutputInfo;
using System;

namespace PLDD.Lab2.MobilePhone
{
    public class SimCorpMobilePhone
    {
        private IOutput Output = null;

        private IPlayback vPlaybackComponent = null;
        public IPlayback PlaybackComponent {
            get { return vPlaybackComponent; }
            set {
                vPlaybackComponent = null;
                if ( value == null ) { throw new ArgumentNullException(nameof(PlaybackComponent)); }
                vPlaybackComponent = value;
                Output.WriteLine($"{vPlaybackComponent.ToString()} playback selected");
                Output.WriteLine("Set playback to Mobile...");
            }
        }

        private ICharge vChargeUnit = null;
        public ICharge ChargeUnit {
            get { return vChargeUnit; }
            set {
                vChargeUnit = null;
                if ( value == null ) { throw new ArgumentNullException(nameof(ChargeUnit)); }
                vChargeUnit = value;
                Output.WriteLine($"{vChargeUnit.ToString()} charge unit selected.");
                Output.WriteLine("Set charge unit to mobile...");
            }
        }

        private ISimCard vSimCard = null;
        public ISimCard SimCard {
            get { return vSimCard; }
            set {
                vSimCard = null;
                if ( value == null ) { throw new ArgumentNullException(nameof(SimCard)); }
                vSimCard = value;
                Output.WriteLine($"{vSimCard.ToString()} sim card to insert is selected.");
                Output.WriteLine("Inserting sim card into mobile...");
            }
        }

        public SimCorpMobilePhone(IOutput output) {
            Output = output;
        }

        public void Play(object data) {
            Output.WriteLine("Play sound in Mobile:");
            PlaybackComponent?.Play(data);
        }

        public void ChargeBattery(object data) {
            Output.WriteLine("Charge battery of mobile:");
            ChargeUnit?.ChargeBattery(data);
        }

        public void ConnectToOperator(object data) {
            Output.WriteLine("Connect to sim card in Mobile:");
            SimCard?.ConnectToOperator(data);
        }
    }
}
