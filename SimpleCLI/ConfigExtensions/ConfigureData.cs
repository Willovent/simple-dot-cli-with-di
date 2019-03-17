using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleCLI.ConfigExtensions
{
    public static class ConfigureDataExtensions
    {
        public static void ConfigureData(this IServiceCollection services) => services.AddDbContext<AppContext>(opt => opt.UseInMemoryDatabase("test"));

        public static void FeedData(this ServiceProvider serviceProvider)
        {
            AppContext context = serviceProvider.GetRequiredService<AppContext>();
            context.Users.Add(new User
            {
                Id = 1,
                FirstName = "William",
                LastName = "Klein"
            });

            context.Users.Add(new User
            {
                Id = 2,
                FirstName = "Rémi",
                LastName = "Lacroix"
            });

            context.SaveChanges();
        }
    }
}
