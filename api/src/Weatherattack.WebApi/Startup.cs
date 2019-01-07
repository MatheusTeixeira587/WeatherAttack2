using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Application.Command.User.Handlers;
using WeatherAttack.Application.Contracts.Command;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Contracts.interfaces;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Application.Mapper.User;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Infra;
using WeatherAttack.Infra.Repositories;
using WeatherAttack.Security.Services;

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
                c.SwaggerDoc("v1", new Info { Title = "WeatherAttackAPI", Version = "v1" });
            });

            //database
            var connectionString = Configuration.GetConnectionString("WeatherAttack");
            services.AddDbContext<WeatherAttackContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<DbContext, WeatherAttackContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMapper<User, UserRequestDto, UserResponseDto>, UserEntityMapper>();

            ConfigureActionHandlers(services);

            services.AddCors();

        }

        public void ConfigureActionHandlers(IServiceCollection services)
        {
            services.AddTransient<IActionHandler<AddUserCommand>, AddUserActionHandler>();
            services.AddTransient<IActionHandler<GetAllUsersCommand>, GetAllUsersActionHandler>();
            services.AddTransient<IActionHandler<GetUserCommand>, GetUserActionHandler>();
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

            app.UseCors(builder => builder.WithOrigins("http://localhost:4500").AllowAnyMethod().AllowAnyHeader());

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
