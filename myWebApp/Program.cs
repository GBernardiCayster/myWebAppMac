using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using myWebApp.Components;
using myWebApp.Data;
using Syncfusion.Blazor;
using myWebApp.Interfaces;
using myWebApp.Services;


namespace myWebApp {
    public class Program {
        public static void Main(string[] args) {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<SecurityDbContext>(options =>
            {
                var connetionString = builder.Configuration.GetConnectionString("SecurityDbConnectionString");
                options.UseMySql(connetionString, ServerVersion.AutoDetect(connetionString));
            });



            builder.Services.AddDbContext<mySQLDbContext>((serviceProvider, dbContextBuilder) =>
            {
                var connectionStringPlaceHolder = builder.Configuration.GetConnectionString("mySQLDbConnectionString");
                var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
                string connectionString = "";
                try
                {
                    var dbName = httpContextAccessor.HttpContext!.Request.Headers["dbname"].First();
                    connectionString = connectionStringPlaceHolder!.Replace("{dbName}", dbName);
                }
                catch {
                    connectionString = connectionStringPlaceHolder!.Replace("{dbName}", "Giuliano");
                }
                dbContextBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            });


            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();

            builder.Services.AddControllers();



            const string JWT_SECURITY_KEY = "yPkCqn4kSWLtaJwXvN2jGzpQRyTZ3gdXkt7FeBJP";

            builder.Services.AddSwaggerGen();
            builder.Services.AddSyncfusionBlazor();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF1cXmhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEFjW31WcXBXRWJVVU11Ww==");


            builder.Services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(JWT_SECURITY_KEY)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            builder.Services.AddTransient<IClientiManager, ClientiManager>();
            builder.Services.AddTransient<IAgentiManager, AgentiManager>();
            builder.Services.AddTransient<IContiCCManager, ContiCCManager>();          
            
            
            builder.Services.AddTransient<IZoneManager, ZoneManager>();
            builder.Services.AddTransient<ITestateListiniManager, TestateListiniManager>();
            builder.Services.AddTransient<ICategorieClientiManager, CategorieClientiManager>();
            builder.Services.AddTransient<ICondizioniPagamentoManager, CondizioniPagamentoManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment()) {
                app.UseWebAssemblyDebugging();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAntiforgery();
            app.UseStaticFiles();
  



            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);
            
            app.MapControllers();


            app.Run();
        }
    }
}
