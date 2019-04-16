using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleLoggingService.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleLoggingService.Controllers
{
    [Route("api/[controller]")]
    public class SimpleLogController : ControllerBase
    {
        private readonly LogInfoContext _context;
        public SimpleLogController(LogInfoContext context)
        {
            _context = context;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> PostLogInfo([FromBody]LogInfo logInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.LogInfos.Add(logInfo);
            await _context.SaveChangesAsync();
            return Ok(logInfo);
        }
    }
}
