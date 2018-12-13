using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Mvc;
using Weatherattack.Infra.Interfaces;
using Weatherattack.Infra.DatabaseOptions;
using WeatherAttack.Security.Services;
using WeatherAttack.Application.Contracts.interfaces;
using Weatherattack.Infra.Repositories;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Domain.Entities;
using Weatherattack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Mapper.User;

namespace Weatherattack.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WeatherAttack API", Version = "v1" });
            });

            //database
            var connectionString = Configuration.GetConnectionString("WeatherAttack");
            //services.AddDbContext<WeatherAttackContext>(options => options.UseSqlServer(connectionString));
            services.AddSingleton<IDatabaseOptions, DataBaseOptions>(options => new DataBaseOptions(connectionString));

            //services
            services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEntityMapper<User, UserRequestDto, UserResponseDto>, UserEntityMapper>();
            services.AddCors();
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

            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherAttack API");
            });

            app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
