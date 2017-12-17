﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone;
using PlugIns;

namespace ConsoleMobilePhone
{
    class Program
    {
        static void Main(string[] args)
        {
            var output = new ConsoleOutput();
            BaseMobilePhone mob = new SimCorpMobilePhone(output);
            //Lab#1
            mob.Description();
            //End of Lab#2

            //Start of Lab#2
            //var playbacks = new List<object>
            //{
            //    new iPhoneHeadset(output),
            //    new SamsungHeadset(output),
            //    new UnofficialHeadset(output),
            //    new PhoneSpeaker(output)
            //};

            //var chargeUnits = new List<object>
            //{
            //    new iChargeUnit(output),
            //    new SamsungChargeUnit(output),
            //    new UnofficialChargeUnit(output)
            //};

            //var simCards = new List<object>
            //{
            //    new KievStarSimCard(output),
            //    new VodafoneSimCard(output),
            //    new LifeSimCard(output)
            //};

            //int index = SelectIndex(playbacks, "Select playback component:");
            //mob.PlaybackComponent = playbacks[index-1] as IPlayback;
            //mob.Play(null);
            //End of Lab#2
        }

        static int SelectIndex(List<object> aObjList, string aRequiredText)
        {
            int index = -1;
            int cnt = aObjList.Count();
            Console.WriteLine(aRequiredText);
            for(int i = 0; i < cnt; ++ i)
            {
                Console.WriteLine($"{i + 1}  -  {aObjList[i].ToString()}");  
            }
            if(!int.TryParse(Console.ReadLine(),out index))
            {
                throw new ArgumentException("Can not parse text into integer");
            }
            if(index > cnt || index < 1 )
            {
                throw new ArgumentOutOfRangeException("Selected index");
            }
  
            return index;
        }
    }
}
