using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoggingService.Data
{
    public class LogInfo
    {
        public int Id { get; set; }
        public string AppName { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Severity { get; set; }
        public string LogMessage { get; set; }

    }
}
