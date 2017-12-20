using System;
using MobilePhone;

namespace ConsoleMobilePhone
{
    class Program
    {
        static void Main(string[] args)
        {
            var mob = new SimCorpMobilePhone();

            Console.WriteLine(mob.ToString());
        }
    }
}
