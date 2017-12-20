using System;
using OutputInfo;


namespace MobilePhonePlugin
{
    public class KievStarSimCard : ISimCard
    {
        private IOutput Output = null;

        public KievStarSimCard(IOutput output) {
            Output = output;
        }
        
        public void ConnectToOperator(object date) {
            if ( Output == null ) { throw new NullReferenceException("Invalid IOutput injected into KievStarSimCard obj." ); }
            Output.WriteLine($"{ToString()} operator is connected.");
        }

        public override string ToString() {
            return "KievStar";
        }
    }
}
