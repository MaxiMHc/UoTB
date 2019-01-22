using System.Threading.Tasks;

namespace Uotb.Interfaces.CQRS
{
    public interface IQueryDispatcher
    {
        Task<TResult> Dispatch<TQuery, TResult>(TQuery query) where TQuery : IQuery;
    }
}
