using PLDD.Lab2.OutputInfo;

namespace PLDD.Lab2.MobilePhonePlugin
{
    public class VodafoneSimCard : ISimCard
    {
        private IOutput Output = null;

        public VodafoneSimCard(IOutput output) {
            Output = output;
        }
        
        public void ConnectToOperator(object date) {
            Output?.WriteLine($"{ToString()} operator is connected.");
        }

        public override string ToString() {
            return "Vodafone";
        }
    }
}
