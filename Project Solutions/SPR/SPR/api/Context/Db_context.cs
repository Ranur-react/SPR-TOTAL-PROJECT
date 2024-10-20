
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using System.Security.Principal;

namespace api.Context
{
    public class Db_context : DbContext
    {
        public Db_context(DbContextOptions<Db_context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies();
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
