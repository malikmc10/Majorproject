using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JPSBillPayment.Models;
using Microsoft.AspNetCore.Http;

namespace JPSBillPayment.Data
{
    public class PaymentContext: DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PaymentContext(DbContextOptions<PaymentContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Payment> Payment { get; set; }
    }
}
