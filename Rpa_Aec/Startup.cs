using AutoMapper;
using EasyCronJob.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rpa_Aec.Domain;
using Rpa_Aec.Infra;
using Rpa_Aec.Repository;
using Rpa_Aec.Services;

namespace Rpa_Aec
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
               .EnableSensitiveDataLogging(true));

            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddServicesConfigurations();
            services.AddRepositoriesConfigurations();

            AddAutoMapperConfiguration(services);

            services.AddHostedService<BuscaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
        }

        private static void AddAutoMapperConfiguration(IServiceCollection services)
        {
            var config = AutoMapperConfig.RegisterMappings();
            config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
