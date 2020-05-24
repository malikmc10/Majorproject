using JPSBillPayment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JPSBillPayment.Data
{
    public class ScotiaCustomerContext: IdentityDbContext<Customer>
    {
        
        public ScotiaCustomerContext(DbContextOptions<ScotiaCustomerContext> options)
            : base(options)
        {
        }

        public DbSet<ScotiaCustomer> ScotiaCustomer { get; set; }

       
    }


}
