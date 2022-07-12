using ApiEvents.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiEvents.Extensions
{
    public static  class ServiceCollectionExtensions
    {
        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<ApiDataContext>((options) =>
            {
                options.UseSqlServer(connectionString);
            });
        }

    }
}
