
namespace PhoneComponents
{
    public class Microphone
    {
        /// <summary>
        /// Describe ability of the microphone to perceive sound 
        /// </summary>
        public float Sensitivity {
            get { return vSensitivity; }
            set { vSensitivity = value; }
        }
        private float vSensitivity;

        public Microphone(float sensitivity) {
            Sensitivity = sensitivity;
        }

        public override string ToString() {
            return $"Microphone:\nSensitivity - {Sensitivity}.\n";
        }
    }
}
