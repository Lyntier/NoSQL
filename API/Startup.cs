using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using NoSQL.DataAccess;
using NoSQL.Models;
using NoSQL.Services;

namespace NoSQL.API
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
            #region settings

            // Required to inject connection string into DataAccess class library.
            services.Configure<Settings>(Configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<ISettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<Settings>>().Value);

            #endregion

            #region repositories

            services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();

            #endregion

            #region services

            services.AddScoped<ITicketService, TicketService>();

            #endregion
            
            #region database

            services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();
            
            #endregion

            services.AddControllers().AddNewtonsoftJson();
        }

        /// <summary> Configures the HTTP request pipeline. </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "/api/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}