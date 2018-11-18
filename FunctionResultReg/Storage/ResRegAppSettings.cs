using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultReg.Storage
{
    public class ResRegAppSettings
    {
        public class Storage
        {
            public class MessageQueue
            {
                public static string QueueName => "QueueName".GetAppSetting<string>("ResReg");
            }
        }
    }
}
