using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServerSide.DAL;
using ServerSide.Environment;

namespace ServerSide
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
            services.AddCors();

            // add mysql
            const string connectionString = "server=localhost;database=todo;user=root;password=1234;SslMode=none;ConnectionReset=true";
            services.AddDbContext<TaskListContext>(options => options.UseMySQL(connectionString));


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            Mapper.Initialize(cfg => cfg.AddProfile(new AutomapperMappingProfile()));

            // Add framefork services
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TaskListContext dbContext)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TaskListContext>();
                context.Database.EnsureCreated();
            }


            app.UseMvc();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
