using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneComponents
{
    public abstract class BaseScreen : PhoneComponent
    {
        private BaseScreen()
        {
            inScreen = null;
            outScreen = null;
        }

        public BaseScreen(int aWidth, int aHeight) : base(aWidth, aHeight)
        {
        }

        private InScreen inScreen;

        private OutScreen outScreen;

        public abstract InScreen InScreen
        { get; }
        public abstract OutScreen OutScreen
        { get; }

        public void Show(IScreenImage aScreenImage)
        {
             OutScreen.Show(aScreenImage);
        }
        public void Show(IScreenImage aScreenImage, int aBrightness)
        {
             OutScreen.Show(aScreenImage, aBrightness);
        }
        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Screen:");
            stringBuilder.AppendLine(OutScreen.ToString());
            stringBuilder.AppendLine(InScreen.ToString());
            return base.GetClassInfo(stringBuilder.ToString());
        }
    }



}
