using ApiEvents.Data.Extensions;
using ApiEvents.Enum;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApiEvents.Data
{
    public class BaseRepository<TContext, TModel> : IRepository<TModel> where TContext : DbContext where TModel : class
    {
        private readonly IDbContextFactory<TContext> _dbContextFactory;

        protected virtual Expression<Func<TModel, bool>>? DefaultCriteria { get; }


        public BaseRepository(IDbContextFactory<TContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IList<TModel>> GetlAll(Expression<Func<TModel, bool>>? condition = null, int? offset = null, int? limit = null)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbset = dbContext.Set<TModel>();
            var query = HandleCondition(dbset, condition);
            query = HandleOffset(query, offset);
            query = HandleLimit(query, limit);
            return await query.ToListAsync();

        }

        public async Task<TModel?> GetByID(Expression<Func<TModel, bool>>? condition = null)
        {
            await using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            var dbset = dbContext.Set<TModel>();
            var query = HandleCondition(dbset, condition);
            return await query.FirstOrDefaultAsync();
        }

        public async Task Delete(TModel model)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var dbset = dbContext.Set<TModel>();
            dbset.Remove(model);
            await dbContext.SaveChangesAsync();
        }

        public async Task<TModel> Insert(TModel model)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var dbset = dbContext.Set<TModel>();
            await dbset.AddAsync(model);
            await dbContext.SaveChangesAsync();
            return model;
        }

        public async Task<TModel> Update(TModel model)
        {
            await using var dbContext = _dbContextFactory.CreateDbContext();
            var dbset = dbContext.Set<TModel>();
            dbset.Update(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
        protected virtual IQueryable<TModel> HandleCondition(IQueryable<TModel> query, Expression<Func<TModel, bool>>? condition)
        {
            var where = condition?.And(DefaultCriteria) ?? DefaultCriteria;
            if (where == null) return query;
            return query.Where(where);
        }

        private static IQueryable<TModel> HandleOffset(IQueryable<TModel> query, int? offset)
        {
            if (offset == null) return query;
            return query.Skip(offset.Value);
        }

        private static IQueryable<TModel> HandleLimit(IQueryable<TModel> query, int? limit)
        {
            if (limit == null) return query;
            return query.Take(limit.Value);
        }

    }


}
