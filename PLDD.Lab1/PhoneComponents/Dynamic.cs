
namespace PhoneComponents
{
    public abstract class Dynamic
    {
        protected int Volume {
            get { return vVolume; }
            set { vVolume = value < 0 ? 0 : value; }
        }
        private int vVolume = 0;

        public Dynamic( ) { }

        public abstract void ChangeVolume(int volume);

        public override string ToString() {
            return "Dynamic type:\n";
        }
    }
}
