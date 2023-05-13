using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShailSoftReactAPI.Models;

namespace ShailSoftReactAPI.Data
{
    public class ShailSoftReactAPIContext : DbContext
    {
        public ShailSoftReactAPIContext (DbContextOptions<ShailSoftReactAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ShailSoftReactAPI.Models.Student> Student { get; set; } = default!;
    }
}
