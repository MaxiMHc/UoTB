using Autofac;
using System.Threading.Tasks;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task<TResult> Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand
        {
            var handler = _context.Resolve<ICommandHandler<TCommand, TResult>>();
            var result = await handler.Execute(command);
            return result;
        }

        public async Task Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _context.Resolve<ICommandHandler<TCommand>>();
            await handler.Execute(command);
        }
    }
}
