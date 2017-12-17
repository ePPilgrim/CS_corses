using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhoneComponents;
using PlugIns;
using OutputInfo;

namespace MobilePhone
{
    public abstract class BaseMobilePhone
    {
     // Start of Lab#1
        private BaseScreen screen;
        private Dynamic dynamic;
        private Microphone mic;
        private Keyboard keyboard;
        private SimCardSlot simka;
        private Battery battery;
        public abstract BaseScreen Screen { get;}
        public abstract Dynamic Dynamic { get;}
        public abstract Microphone Mic { get;}
        public abstract Keyboard Keyboard { get;}
        public abstract SimCardSlot Simka { get;}
        public abstract Battery Battery { get;}
        public void Description()
        {
            Console.WriteLine(Screen.ToString());
            Console.WriteLine(Dynamic.ToString());
            Console.WriteLine(Mic.ToString());
            Console.WriteLine(Keyboard.ToString());
            Console.WriteLine(Simka.ToString());
            Console.WriteLine(Battery.ToString());
        }
        // End Of Lab#1

        //Start of Lab#2
        public BaseMobilePhone(IOutput aOutput = null)
        {
            output = aOutput;
        }

        private IOutput output = null;
        private IPlayback playbackComponent = null;
        private ICharge chargeUnit = null;
        private ISimCard simCard = null;
        public IPlayback PlaybackComponent {
            get
            {
                return playbackComponent;
            }
            set
            {
                playbackComponent = null;
                if(value == null)
                {
                    throw new ArgumentNullException(nameof(PlaybackComponent)); 
                }
                playbackComponent = value;
                output.WriteLine($"{playbackComponent.ToString()} playback selected");
                output.WriteLine("Set playback to Mobile...");            
            }
        }
        public ICharge ChargeUnit { get { return chargeUnit; }
            set
            {
                chargeUnit = null;
                if(value == null)
                {
                    throw new ArgumentNullException(nameof(ChargeUnit));
                }
                chargeUnit = value;
                output.WriteLine($"{chargeUnit.ToString()} charge unit selected.");
                output.WriteLine("Set charge unit to mobile...");
            }
        }
        public ISimCard SimCard { get { return simCard; }
            set {
                simCard = null;
                if(value == null)
                {
                    throw new ArgumentNullException(nameof(SimCard));
                }
                simCard = value;
                output.WriteLine($"{simCard.ToString()} sim card to insert is selected.");
                output.WriteLine("Inserting sim card into mobile...");
            } }

        public void Play(object data)
        {
            output.WriteLine("Play sound in Mobile:");
            PlaybackComponent?.Play(data);
        }
        public void ChargeBattery(object data)
        {
            output.WriteLine("Charge battery of mobile:");
            ChargeUnit?.ChargeBattery(data);
        }
        public void ConnectToOperator(object data)
        {
            output.WriteLine("Connect to sim card in Mobile:");
            SimCard?.ConnectToOperator(data);
        }
        //End of Lab#2

    }
}
