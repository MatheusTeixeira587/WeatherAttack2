using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherAttack.Application.Command.Character;
using WeatherAttack.Application.Command.Character.Handlers;
using WeatherAttack.Application.Command.Spell;
using WeatherAttack.Application.Command.Spell.Handlers;
using WeatherAttack.Application.Command.User;
using WeatherAttack.Application.Command.User.Handlers;
using WeatherAttack.Application.Command.Weather;
using WeatherAttack.Application.Command.Weather.Handlers;
using WeatherAttack.Application.Mapper.Spell;
using WeatherAttack.Application.Mapper.SpellRule;
using WeatherAttack.Application.Mapper.User;
using WeatherAttack.Application.Mapper.Weather;
using WeatherAttack.Contracts.Command;
using WeatherAttack.Contracts.Dtos.Spell.Request;
using WeatherAttack.Contracts.Dtos.SpellRule.Request;
using WeatherAttack.Contracts.Dtos.User.Request;
using WeatherAttack.Contracts.Dtos.User.Response;
using WeatherAttack.Contracts.Dtos.Weather.Request;
using WeatherAttack.Contracts.interfaces;
using WeatherAttack.Contracts.Interfaces;
using WeatherAttack.Contracts.Mapper;
using WeatherAttack.Domain.Contracts;
using WeatherAttack.Domain.Entities;
using WeatherAttack.Domain.Entities.Weather;
using WeatherAttack.Hub.Hubs.Challenge;
using WeatherAttack.Infra;
using WeatherAttack.Infra.Repositories;
using WeatherAttack.Infra.Services;
using WeatherAttack.Security.Commands;
using WeatherAttack.Security.Commands.Handlers;
using WeatherAttack.Security.Entities;
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Configuration["SecuritySettings:SigningKey"])
                        )
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            var path = context.HttpContext.Request.Path;

                            if (!string.IsNullOrEmpty(accessToken) 
                                && path.StartsWithSegments("/challenge"))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                });

            services.Configure<SecuritySettings>(options => Configuration.GetSection("SecuritySettings").Bind(options));            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "WeatherAttackAPI", Version = "v1" });

                c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = "header",
                    Type = "apiKey"
                });

                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                {
                    { "Bearer", new string[] { } } 
                });
            });

            ConfigureDatabase(services);
            ConfigureRepositories(services);
            ConfigureMappers(services);
            ConfigureCommonServices(services);
            ConfigureActionHandlers(services);

            services.AddSignalR();

            services.AddCors();
        }

        public void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISpellRepository, SpellRepository>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
        }

        public void ConfigureDatabase(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("WeatherAttack");

            services.AddDbContext<WeatherAttackContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<DbContext, WeatherAttackContext>(options => options.UseSqlServer(connectionString));
        }

        public void ConfigureCommonServices(IServiceCollection services)
        {
            string OpenWeatherMapApiKey = Configuration["WebServices:OpenWeatherMap:ApiKey"];
            string OpenWeatherMapUrl = Configuration["WebServices:OpenWeatherMap:Url"];

            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IOpenWeatherMapService, OpenWeatherMapWebService>(p => new OpenWeatherMapWebService(OpenWeatherMapUrl, OpenWeatherMapApiKey));
        }

        public void ConfigureMappers(IServiceCollection services)
        {
            services.AddTransient<IMapper<User, UserRequestDto, UserResponseDto>, UserEntityMapper>();
            services.AddTransient<IMapper<SpellRule, SpellRuleRequestDto, SpellRuleRequestDto>, SpellRuleEntityMapper>();
            services.AddTransient<IMapper<Spell, SpellRequestDto, SpellRequestDto>, SpellEntityMapper>();
            services.AddTransient<IMapper<Wind, WindRequestDto, WindRequestDto>, WindEntityMapper>();
            services.AddTransient<IMapper<Rain, RainRequestDto, RainRequestDto>, RainEntityMapper>();
            services.AddTransient<IMapper<Coordinates, CoordinatesRequestDto, CoordinatesRequestDto>, CoordinatesEntityMapper>();
            services.AddTransient<IMapper<Weather, WeatherRequestDto, WeatherRequestDto>, WeatherEntityMapper>();
            services.AddTransient<IMapper<Main, MainRequestDto, MainRequestDto>, MainWeatherEntityMapper>();
            services.AddTransient<IMapper<CurrentWeather, CurrentWeatherRequestDto, CurrentWeatherRequestDto>, CurrentWeatherEntityMapper>();
            services.AddTransient<IMapper<CountryInfo, CountryInfoRequestDto, CountryInfoRequestDto>, CountryInfoEntityMapper>();
        }

        public void ConfigureActionHandlers(IServiceCollection services)
        {
            services.AddTransient<IActionHandler<LoginCommand>, LoginActionHandler>();

            services.AddTransient<IActionHandler<AddUserCommand>, AddUserActionHandler>();
            services.AddTransient<IActionHandler<GetAllUsersCommand>, GetAllUsersActionHandler>();
            services.AddTransient<IActionHandler<GetUserCommand>, GetUserActionHandler>();
            services.AddTransient<IActionHandler<DeleteUserCommand>, DeleteUserActionHandler>();

            services.AddTransient<IActionHandler<GetSpellCommand>, GetSpellActionHandler>();
            services.AddTransient<IActionHandler<GetAllSpellsCommand>, GetAllSpellsActionHandler>();
            services.AddTransient<IActionHandler<AddSpellCommand>, AddSpellActionHandler>();
            services.AddTransient<IActionHandler<DeleteSpellCommand>, DeleteSpellActionHandler>();

            services.AddTransient<IActionHandler<GetCharacterCommand>, GetCharacterActionHandler>();

            services.AddTransient<IActionHandler<GetCurrentWeatherCommand>, GetCurrentWeatherActionHandler>();
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

            app.UseAuthentication();

            app.UseCors(builder => 
                builder.WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherAttack API");
            });

            app.UseRewriter(new RewriteOptions().AddRedirect("^$", "swagger"));
            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSignalR(routes =>
            {
                routes.MapHub<Challenge>("/challenge");
            });
        }
    }
}
