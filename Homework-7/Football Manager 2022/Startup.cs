using Football_Manager_2022.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Football_Manager_2022.ServiceAbstracts;
using Football_Manager_2022.ServiceImplementetions;
using Football_Manager_2022.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Football_Manager_2022
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
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<ICoachService, CoachService>();
            services.AddTransient<IFootballerService, FootballerServices>();
            services.AddTransient<ITacticService, TacticService>();
            services.AddTransient<IPositionService, PositionService>();
            services.AddTransient<INationalTeamService, NationalTeamService>();
            services.AddTransient<IManagementPositionService, ManagementPositionService>();
            services.AddTransient<IManagerService, ManagerService>();

            services.AddTransient<IUnitOfWork,UnitOfWork.UnitOfWork >();
            services.AddDbContext<ApplicationDbContext>(x =>
            {
                x.EnableSensitiveDataLogging();
                x.UseSqlServer(Configuration.GetConnectionString("Default"));
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FootballManagerApi", Version = "v1" });
            });
            // services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FootballManagerApi v1"));
            }
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
