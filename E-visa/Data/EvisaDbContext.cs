using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;
using E_Visa.Models;
using MathNet.Numerics.Distributions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace E_Visa.Data
{
    public class EvisaDbContext : IdentityDbContext<AppUser>
    {
        public EvisaDbContext(DbContextOptions<EvisaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EvisaForm>()
                .HasOne(e => e.AppUser)
                .WithMany(a => a.EvisaForm)
                .HasForeignKey(e => e.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<EvisaForm> EvisaForm { get; set; }
    }
}



