using HauntedHouse.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse.Data
{
    public class HauntedHouseContext : DbContext
    {
        public HauntedHouseContext(DbContextOptions<HauntedHouseContext> options) : base(options) { }
        public DbSet<Hunter> Hunters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<FileToDatabase> FileToDatabase { get; set; }
    }
}
