using Autofac;
using System.Threading.Tasks;
using Uotb.Interfaces.CQRS;

namespace Uotb.Api.CQRS
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IComponentContext _context;

        public QueryDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task<TResult> Dispatch<TQuery, TResult>(TQuery query)
            where TQuery : IQuery
        {
            var handler = _context.Resolve<IQueryHandler<TQuery, TResult>>();
            var queryResult = await handler.Handle(query);

            return queryResult;
        }
    }
}
