using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recipe_App.Models;

namespace Recipe_App.Data
{
    public class Recipe_AppContext : DbContext
    {
        public Recipe_AppContext (DbContextOptions<Recipe_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe_App.Models.Login> Login { get; set; } = default!;
    }
}
