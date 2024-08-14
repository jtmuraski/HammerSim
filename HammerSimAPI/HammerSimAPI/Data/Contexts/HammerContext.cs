using HammerSimAPI.Models.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace HammerSimAPI.Data.Contexts
{
    public class HammerContext : DbContext
    {
        public DbSet<Unit> Units { get; set; }
        public DbSet<Models.Data.ShootingResults> ShootingResults { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=HammerSim.sqlite");
        }
    }
}
