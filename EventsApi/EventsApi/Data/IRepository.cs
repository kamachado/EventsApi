using ApiEvents.Enum;
using System.Linq.Expressions;

namespace ApiEvents.Data
{
    public interface IRepository<TModel>
    {
        Task<IList<TModel>> GetlAll(Expression<Func<TModel, bool>>? condition = null, int? offset = null, int? limit = null);

        Task<TModel?> GetByID(Expression<Func<TModel, bool>>? condition = null);

        Task<TModel> Insert(TModel model);

        Task<TModel> Update(TModel model);

        Task Delete(TModel model);
    }
}
