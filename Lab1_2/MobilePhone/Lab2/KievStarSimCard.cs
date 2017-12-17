using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutputInfo;


namespace PlugIns
{
    public class KievStarSimCard : ISimCard
    {
        public KievStarSimCard(IOutput aOutput)
        {
            output = aOutput;
        }
        private IOutput output = null;
        public void ConnectToOperator(object date)
        {
            output.WriteLine($"{ToString()} operator is connected.");
        }

        public override string ToString()
        {
            return "KievStar";
        }
    }
}
