using AuthService.Server.auth;
using AuthService.Server.Notification;
using AuthService.Server.Role;
using AuthService.Server.Role.Chucnang;
using AuthService.Server.Role.Phanquyen;
using AuthService.Server.Role.QuyenSudungChucnang;
using AuthService.Server.user;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Model.Connection;
using Model.Connection.SQLServer;

namespace AuthService
{
    public class Startup
    {
        Connection connection = new Connection();
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<Iauth, AuthImpl>();
            services.AddScoped<Iuser, UserImpl>();
            services.AddScoped<Inotification, NotificationImpl>();
            services.AddScoped<Iphanquyen, PhanquyenImpl>();
            services.AddScoped<Iquyen, QuyenImpl>();
            services.AddScoped<Ichucnang, ChucnangImpl>();
            services.AddScoped<IquyenSudungChucnang, QuyenSudungChucnangImpl>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connection.connectionStringSQL));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
