using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAppHangFire.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        [HttpGet("RodarUmaVez")]
        public IActionResult RodarUmaVez()
        {
            var job = BackgroundJob.Enqueue(() => Action.RodarUmaVez());

            return Ok(job);
        }

        [HttpGet("RodarAposAlgumTempo")]
        public IActionResult RodarAposTempo()
        {
            var job = BackgroundJob.Schedule(() => Action.RodarAposTempo(), TimeSpan.FromSeconds(5));

            return Ok(job);
        }

        [HttpGet("RodarSempre")]
        public IActionResult RodarSempre()
        {
            RecurringJob.AddOrUpdate(() => Action.RodarSempre(), Cron.Minutely());

            return Ok();
        }
    }
}
