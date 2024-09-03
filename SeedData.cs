using Microsoft.EntityFrameworkCore;
using Recipe_App.Data;
using Recipe_App.Models;

namespace Recipe_App
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Recipe_AppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Recipe_AppContext>>()))
            {
                if (context.Login.Any())
                {
                    return;
                }
                context.Login.AddRange(
                    new Login
                    {
                        Id="user",
                        Password="pwd123"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
