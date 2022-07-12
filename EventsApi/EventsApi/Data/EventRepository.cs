using ApiEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEvents.Data
{
    public class EventRepository : BaseRepository<ApiDataContext, Event>, IRepository<Event>
    {
        public EventRepository(IDbContextFactory<ApiDataContext> dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}
