using CustomerApp.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomerApp.Data;
using CustomerApp.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using CustomerApp.Dataa;
using Microsoft.Extensions.Configuration;
using CustomerApp.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using ikvm.runtime;
using System.Reflection;
using AutoMapper;



namespace CustomerApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();
            builder.Services.AddDbContext<CustomerAppContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

            // Register your application services
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IReservasjonsService, ReservasjonsService>();

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "auth_token";
                    options.LoginPath = "/login";
                    options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                    options.AccessDeniedPath = "/accessdenied";
                });


            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
        .AddEntityFrameworkStores<CustomerAppContext>();


            builder.Services.AddControllers();
            builder.Services.AddAuthorization();
            builder.Services.AddCascadingAuthenticationState();
            var mapperConfiguration = new MapperConfiguration(configuration =>
            {
                var profile = new UserProfile();
                configuration.AddProfile(profile);
            });
            var mapper = mapperConfiguration.CreateMapper();
            builder.Services.AddSingleton(mapper);



            builder.Services.AddHttpClient();


            var apiBaseUrl = builder.Configuration.GetValue<string>("ApiBaseUrl");

            builder.Services.AddHttpClient("MyClient", client =>
            {
                client.BaseAddress = new Uri(apiBaseUrl);
            });


           


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();


            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}