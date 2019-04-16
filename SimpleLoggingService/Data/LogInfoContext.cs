using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleLoggingService.Data
{
    public class LogInfoContext : DbContext
    {
        public LogInfoContext(DbContextOptions<LogInfoContext> options) : base(options)
        {

        }

        public DbSet<LogInfo> LogInfos { get; set; }
    }
}
