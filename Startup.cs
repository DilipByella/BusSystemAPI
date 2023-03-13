using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using BusSystem.API.Data;
using BusSystem.API.Repository;
using BusSystem.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BusSystem.API
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
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "https://localhost:44345",
                        ClockSkew = TimeSpan.Zero,
                        ValidAudiences = new List<string>
                        {
                            "https://localhost:44345",
                            "https://localhost:4200"
                        },
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YEg6R89Mlv21JbwO"))
                    };
                });


            services.AddDbContext<BusDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));

            #region AddTransients
            services.AddTransient<IUserRepo, UserRepo>();
            services.AddTransient<UserServices, UserServices>();
            services.AddTransient<ITransactionRepo, TransactionRepo>();
            services.AddTransient<TransactionServices, TransactionServices>();
            services.AddTransient<ISeatRepo, SeatRepo>();
            services.AddTransient<SeatServices, SeatServices>();
            services.AddTransient<IBankCredRepo, BankCredRepo>();
            services.AddTransient<BankCredServices, BankCredServices>();
            services.AddTransient<ITicketRepo, TicketRepo>();
            services.AddTransient<TicketServices, TicketServices>();
            services.AddTransient<IBookingRepo, BookingRepo>();
            services.AddTransient<BookingServices, BookingServices>();
            services.AddTransient<IQuotaRepo, QuotaRepo>();
            services.AddTransient<QuotaServices, QuotaServices>();
            services.AddTransient<ITicketRepo, TicketRepo>();
            services.AddTransient<TicketServices, TicketServices>();
            services.AddTransient<IBusRepo, BusRepo>();
            services.AddTransient<BusServices, BusServices>();
            services.AddTransient<IPassengerRepo, PassengerRepo>();
            services.AddTransient<PassengerServices, PassengerServices>();
            #endregion

            services.AddCors();
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).AddNewtonsoftJson(
                options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BusSystem.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BusSystem.API v1"));
            }
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
