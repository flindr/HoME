using HoMeAPI.Entities;
using HoMeAPI.Models;
using HoMeAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace HoMeAPI
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
            services.AddMvc();

            services.AddCors();

            var connectionString = Configuration["ConnectionStrings:MeasurementsDbConnectionString"];
            services.AddDbContext<MeasurementsContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<IMeasurementsRepository, MeasurementsRepository>();
            services.AddScoped<IBodyMeasurementsRepository, BodyMeasurementsRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            loggerFactory.AddDebug();

            loggerFactory.AddNLog();

            app.UseCors(builder =>
                builder.WithOrigins("http://fredriklindrothhome.azurewebsites.net")
                    .AllowAnyHeader()
            );

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            AutoMapper.Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<MeasurementDto, Measurement>();
                    cfg.CreateMap<BodyMeasurementDto, BodyMeasurement>();
                }
            );
            
            app.UseMvc();
        }
    }
}
