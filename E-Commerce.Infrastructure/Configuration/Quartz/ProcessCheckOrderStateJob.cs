using E_Commerce.Application.Command.OrderCommand.CheckOrderStates;
using MediatR;
using Quartz;


namespace E_Commerce.Infrastructure.Configuration.Quartz
{
    [DisallowConcurrentExecution]
    public class ProcessCheckOrderStateJob : IJob
    {
        private readonly IMediator mediator;

        public ProcessCheckOrderStateJob(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var result = await mediator.Send(new CheckOrdersStateCommand());

            await Task.CompletedTask;
        }
    }
}
