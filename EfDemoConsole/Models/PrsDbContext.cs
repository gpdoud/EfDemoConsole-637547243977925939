using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Text;

namespace EfDemoConsole.Models {

    public class PrsDbContext : DbContext {

        private static string connectionString = "server=localhost\\sqlexpress;database=PrsDb30;trusted_connection=true;";

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if(!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<User>(entity => {
                entity.HasIndex(x => x.Username).IsUnique();
            });
        }
    }
}
