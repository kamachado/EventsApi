using ApiEvents.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiEvents.Data
{
    public class ApiDataContext : DbContext
    {
        public DbSet<EventPlace> EventPlace{ get; set; }
        public ApiDataContext(DbContextOptions<ApiDataContext> options) : base(options)
        {

        }

    }
}
