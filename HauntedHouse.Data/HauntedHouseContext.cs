using HauntedHouse.Core.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Data
{
    public class HauntedHouseContext : IdentityDbContext<ApplicationUser>
    {
        public HauntedHouseContext(DbContextOptions<HauntedHouseContext> options) : base(options) { }
        public DbSet<Hunter> Hunters { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
        public DbSet<IdentityRole> IdentityRoles { get; set; }
    }
}
