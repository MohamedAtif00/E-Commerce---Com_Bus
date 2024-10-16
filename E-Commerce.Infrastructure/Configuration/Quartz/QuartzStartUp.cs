using E_Commerce.Application.Command.OrderCommand.CheckOrderStates;
using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace E_Commerce.Infrastructure.Configuration.Quartz
{
    public class QuartzStartUp
    {
        private static IScheduler _scheduler;

        public static void Initialize()
        {
            // Scheduler configuration (optional)
            var schedulerConfiguration = new NameValueCollection
            {
                { "quartz.scheduler.instanceName", "ECommerceScheduler" }
            };

            // Create a scheduler factory
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory(schedulerConfiguration);
            _scheduler = schedulerFactory.GetScheduler().GetAwaiter().GetResult();

            // Start the scheduler
            _scheduler.Start().GetAwaiter().GetResult();

            // Define the job and link it to ProcessCheckOrderStateJob
            var checkOrderStateJob = JobBuilder.Create<ProcessCheckOrderStateJob>()
                .WithIdentity("checkOrderStateJob", "group1") // Job identity
                .Build();

            // Create a trigger for every 2 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("checkOrderStateTrigger", "group1") // Trigger identity
                .StartNow()
                .WithCronSchedule("0/20 * * ? * *") // Cron for every 20 seconds
                .Build();

            // Schedule the job
            _scheduler.ScheduleJob(checkOrderStateJob, trigger).GetAwaiter().GetResult();
        }

        public static void Shutdown()
        {
            if (_scheduler != null)
            {
                _scheduler.Shutdown().GetAwaiter().GetResult();
            }
        }
    }
}
