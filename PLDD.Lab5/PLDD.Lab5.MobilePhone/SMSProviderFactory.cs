

namespace PLDD.Lab5.MobilePhone
{
    internal class SMSProviderFactory
    {
        static public SMSProvider GetSmsProvider(JobType jobType)
        {
            switch (jobType)
            {
                case JobType.Thread:
                    return new SMSProviderByThread();
                case JobType.Task:
                    return new SMSProviderByTask();
                default:
                    return null;
            }
        }
    }
}
