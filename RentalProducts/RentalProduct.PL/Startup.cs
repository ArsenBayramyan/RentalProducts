using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentalProducts.BLL.Repository;
using RentalProducts.Core.Interfaces;
using RentalProducts.DAL.Contexts;
using RentalProducts.DAL.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using RentalProducts.Core.Infrastructure;

namespace RentalProducts
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            var productsConString = Configuration["Data:Products:ConnectionString"];
            var identityConString = Configuration["Data:RentalProductsIdentity:ConnectionString"];
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(productsConString));
            services.AddDbContext<AppIdentityDbContext>(options =>
                    options.UseSqlServer(identityConString));
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddSingleton<IProduct, Product>();
            services.AddSingleton<ICustomer, Customer>();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}
