
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using System.Security.Principal;
using api.BaseModels;

namespace api.Context
{
    public class Db_context : DbContext
    {
        public Db_context(DbContextOptions<Db_context> options) : base(options)
        {

        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<BaseEntity>();
            Console.WriteLine($"Entries Count: {entries.Count()}"); // Debugging
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "System"; // Ganti dengan username dari context atau JWT
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdateDate = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = "System"; // Ganti dengan username dari context atau JWT
                }
            }

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateDate = DateTime.UtcNow;
                    entry.Entity.CreatedBy = "System"; // Ganti dengan username dari context atau JWT
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdateDate = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = "System"; // Ganti dengan username dari context atau JWT
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApprovalSPR>()
            .HasOne(a => a.UserApprover)
            .WithMany()
            .HasForeignKey(a => a.UserApproverId)
            .OnDelete(DeleteBehavior.NoAction);
        }
     
        public DbSet<User> Users { get; set; }
        public DbSet<Proyek> Proyeks { get; set;}
        public DbSet<Material>Materials { get; set; }
        public DbSet<SPR> Headers_SP { get; set; }
        public DbSet<DetilSPR> Detils_SPR { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<ApprovalSPR> approvalSPRs { get; set; }
        public DbSet<LogSPR> logSPRs { get; set; }
       

    }
}
