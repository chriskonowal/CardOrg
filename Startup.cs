using CardOrg.Factory;
using CardOrg.Interfaces.Factories;
using CardOrg.Interfaces.Repositories;
using CardOrg.Interfaces.Services;
using CardOrg.Repositories;
using CardOrg.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardOrg
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
            services.AddRazorPages();
            services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();
            services.AddTransient<ICardRepository, CardRepository>();
            services.AddTransient<ICardService, CardService>();
            services.AddTransient<ISportRepository, SportRepository>();
            services.AddTransient<ISportService, SportService>();
            services.AddTransient<IYearRepository, YearRepository>();
            services.AddTransient<IYearService, YearService>();
            services.AddTransient<IGradeCompanyRepository, GradeCompanyRepository>();
            services.AddTransient<IGradeCompanyService, GradeCompanyService>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<ILocationService, LocationService>();
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<ISetRepository, SetRepository>();
            services.AddTransient<ISetService, SetService>();
            services.AddTransient<ITeamRepository, TeamRepository>();
            services.AddTransient<ITeamService, TeamService>();
            services.AddTransient<IPlayerCardRepository, PlayerCardRepository>();
            services.AddTransient<ITeamCardRepository, TeamCardRepository>();
            services.AddTransient<ISearchSortRepository, SearchSortRepository>();
            services.AddTransient<ISearchSortService, SearchSortService>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
