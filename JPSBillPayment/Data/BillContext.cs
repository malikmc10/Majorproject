using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JPSBillPayment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JPSBillPayment.Data
{
    public class BillContext : IdentityDbContext<Customer>
    {
        public BillContext(DbContextOptions<BillContext> options)
            : base(options)
        {
        }

        public DbSet<Bill> Bill { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            builder.Entity<Bill>()
                .HasIndex(u => u.premisesNumber)
                .IsUnique();

            builder.Entity<Bill>()
                .HasIndex(u => u.customerId)
                .IsUnique();
        }
    }
}
