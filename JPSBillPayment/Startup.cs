using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using JPSBillPayment.Data;
using Microsoft.AspNetCore.Identity;
using JPSBillPayment.Models;
using Microsoft.AspNetCore.Http;

namespace JPSBillPayment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            
            services.AddDbContext<BillContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("BillContext")));

            services.AddDbContext<PaymentContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("BillContext")));

            services.AddDbContext<ScotiaCustomerContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("BillContext")));


            services.AddDbContext<ScotiaTransactionContext>(options =>
          options.UseSqlServer(Configuration.GetConnectionString("BillContext")));

            services.AddIdentity<Customer, IdentityRole>()
               .AddEntityFrameworkStores<BillContext>();

           

            //services.AddIdentity<ScotiaCustomer, IdentityRole>()
            //.AddEntityFrameworkStores<BillContext>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
