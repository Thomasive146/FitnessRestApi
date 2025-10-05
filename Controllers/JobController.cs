using FitnessRestApi.Jobs;
using Microsoft.AspNetCore.Mvc;
using Quartz;

namespace FitnessRestApi.Controllers
{
    [ApiController]
    [Route("job")]
    public class JobController : ControllerBase
    {
        private readonly ISchedulerFactory _schedulerFactory;

        public JobController(ISchedulerFactory schedulerFactory)
        {
            _schedulerFactory = schedulerFactory;
        }

        [HttpPost("schedule")]
        public async Task<IActionResult> ScheduleReminder(string message, string email)
        {
            var scheduler = await _schedulerFactory.GetScheduler();

            var job = JobBuilder.Create<ReminderJob>()
                .UsingJobData("Message", message)
                .UsingJobData("Email", email)
                .WithIdentity(Guid.NewGuid().ToString())
                .Build();

            var trigger = TriggerBuilder.Create()
                .StartNow()
                .WithSimpleSchedule(x => x.WithMisfireHandlingInstructionFireNow())
                .Build();

            await scheduler.ScheduleJob(job, trigger);

            return Ok(new { Message = message, Email = email });
        }
    }
}
