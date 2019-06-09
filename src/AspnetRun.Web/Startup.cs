using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Services;
using AspnetRun.Core.Interfaces;
using AspnetRun.Infrastructure.Logging;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository;
using AspnetRun.Web.HealthChecks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Repositories.Base;
using AspnetRun.Core.Configuration;
using AspnetRun.Infrastructure.Repository.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;

namespace AspnetRun.Web
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
            // aspnetrun dependencies
            ConfigureAspnetRunServices(services);

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }

        private void ConfigureAspnetRunServices(IServiceCollection services)
        {
            // Add Core Layer
            services.Configure<AspnetRunSettings>(Configuration);

            // Add Infrastructure Layer
            ConfigureDatabases(services);
            ConfigureIdentity(services);

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IWishlistRepository, WishlistRepository>();
            

            // Add Application Layer
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IWishListService, WishListService>();

            // Add Web Layer
            services.AddAutoMapper(); // Add AutoMapper
            services.AddScoped<IIndexPageService, IndexPageService>();
            services.AddScoped<IProductPageService, ProductPageService>();
            services.AddScoped<ICategoryPageService, CategoryPageService>();
            services.AddScoped<IWishlistPageService, WishlistPageService>();

            // Add Miscellaneous
            services.AddHttpContextAccessor();
            services.AddHealthChecks()
                .AddCheck<IndexPageHealthCheck>("home_page_health_check");
        }

        public void ConfigureDatabases(IServiceCollection services)
        {
            //// use in-memory database
            //services.AddDbContext<AspnetRunContext>(c =>
            //    c.UseInMemoryDatabase("AspnetRunConnection"));

            // use real database
            services.AddDbContext<AspnetRunContext>(c =>
                c.UseSqlServer(Configuration.GetConnectionString("AspnetRunConnection"), x => x.MigrationsAssembly("AspnetRun.Web")));
        }

        public void ConfigureIdentity(IServiceCollection services)
        {
            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<AspnetRunContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
            });
        }
    }
}
