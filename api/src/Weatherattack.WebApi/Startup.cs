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
using WeatherAttack.Application.Contracts.Dtos.Spell.Request;
using WeatherAttack.Application.Contracts.Dtos.SpellRule.Request;
using WeatherAttack.Application.Contracts.Dtos.User.Request;
using WeatherAttack.Application.Contracts.Dtos.User.Response;
using WeatherAttack.Application.Contracts.interfaces;
using WeatherAttack.Application.Mapper;
using WeatherAttack.Application.Mapper.Spell;
using WeatherAttack.Application.Mapper.SpellRule;
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

            ConfigureDatabase(services);
            ConfigureRepositories(services);
            ConfigureMappers(services);
            ConfigureCommonServices(services);
            ConfigureActionHandlers(services);

            services.AddCors();
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISpellRepository, SpellRepository>();
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("WeatherAttack");
            services.AddDbContext<WeatherAttackContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<DbContext, WeatherAttackContext>(options => options.UseSqlServer(connectionString));
        }

        public void ConfigureCommonServices(IServiceCollection services)
        {
            services.AddTransient<IPasswordService, PasswordService>();
            
        }

        public void ConfigureMappers(IServiceCollection services)
        {
            services.AddTransient<IMapper<User, UserRequestDto, UserResponseDto>, UserEntityMapper>();
            services.AddTransient<IMapper<SpellRule, SpellRuleRequestDto, SpellRuleRequestDto>, SpellRuleEntityMapper>();
            services.AddTransient<IMapper<Spell, SpellRequestDto, SpellRequestDto>, SpellEntityMapper>();
        }

        public void ConfigureActionHandlers(IServiceCollection services)
        {
            services.AddTransient<IActionHandler<AddUserCommand>, AddUserActionHandler>();
            services.AddTransient<IActionHandler<GetAllUsersCommand>, GetAllUsersActionHandler>();
            services.AddTransient<IActionHandler<GetUserCommand>, GetUserActionHandler>();
            services.AddTransient<IActionHandler<DeleteUserCommand>, DeleteUserActionHandler>();
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
