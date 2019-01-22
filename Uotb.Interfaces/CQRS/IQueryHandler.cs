using System.Threading.Tasks;

namespace Uotb.Interfaces.CQRS
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery
    {
        Task<TResult> Handle(TQuery query);
    }
}
