namespace PLDD.Lab5.MobilePhone
{

    internal static class BatteryFactory
    {
        static public int CurrentCharge = 100;

        static public int MaxValueOfCharge = 100;

        static public Battery GetBattery(JobType jobType) {
            switch (jobType) {
                case JobType.Thread:
                    return new BatterChargedByThread(CurrentCharge, MaxValueOfCharge);
                case JobType.Task:
                    return new BatteryChargedByTask(CurrentCharge, MaxValueOfCharge);
                default:
                    return null;
            }
        }
    }
}
