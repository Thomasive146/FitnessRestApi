using Quartz;

namespace FitnessRestApi.Jobs
{
    public class ReminderJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            var reminderText = context.JobDetail.JobDataMap.GetString("Message");
            var userEmail = context.JobDetail.JobDataMap.GetString("Email");

            // For demo: just log it
            Console.WriteLine($"[Reminder] Sending to {userEmail}: {reminderText}");

            // TODO: Replace with email service or SignalR notification
            await Task.CompletedTask;
        }
    }
}
