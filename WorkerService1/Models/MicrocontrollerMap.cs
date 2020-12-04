using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService1.Models
{
    class MicrocontrollerMap
    {
        public static readonly Dictionary<int, string> IpMapId =
            new Dictionary<int, string>()
            {
                {1, "192.168.1.177" },
                //{2, "192.168.1.177" }
            };
    }
}
