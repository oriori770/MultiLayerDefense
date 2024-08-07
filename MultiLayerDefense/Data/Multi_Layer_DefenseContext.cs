using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Multi_Layer_Defense.Models;

namespace Multi_Layer_Defense.Data
{
    public class Multi_Layer_DefenseContext : DbContext
    {
        public Multi_Layer_DefenseContext (DbContextOptions<Multi_Layer_DefenseContext> options)
            : base(options)
        {
        }

        public DbSet<Multi_Layer_Defense.Models.Inventory> Inventory { get; set; } = default!;
        public DbSet<Multi_Layer_Defense.Models.Interceptor> Interceptor { get; set; } = default!;
        public DbSet<Multi_Layer_Defense.Models.Weapon> Weapon { get; set; } = default!;
        public DbSet<Multi_Layer_Defense.Models.Threat> Threat { get; set; } = default!;
        public DbSet<Multi_Layer_Defense.Models.Response> Response { get; set; } = default!;
    }
}
