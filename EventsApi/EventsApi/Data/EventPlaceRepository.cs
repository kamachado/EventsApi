using ApiEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEvents.Data
{
    public class EventPlaceRepository : BaseRepository<ApiDataContext, EventPlace>, IRepository<EventPlace>
    {
        public EventPlaceRepository(IDbContextFactory<ApiDataContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
