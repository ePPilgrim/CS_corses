
using System;

public enum SimCardType {
    Nano,
    Mini,
    Micro
}

namespace PhoneComponents
{
    public class SimCardSlot
    {
        public SimCardType vTypeOfSimCard;
        public SimCardType TypeOfSimCard {
            get { return vTypeOfSimCard; }
            set {
                if (value.GetType().Equals(typeof(SimCardType))) { vTypeOfSimCard = value; }
                else { throw new ArgumentException("Invalide value of Sim Card type."); }
            }
        }

        public SimCardSlot( SimCardType typeOfSimCard ) { TypeOfSimCard = typeOfSimCard; }

        public override string ToString()
        {
            return $"SimCardSlot:\nType of Sim Card - {vTypeOfSimCard.ToString()}.\n";
        }
    }
}
