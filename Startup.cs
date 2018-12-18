using Quote2Invoice.UI.Shared.WebApiCaller;
using Quote2Invoice.UI.Shared;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.DataProtection;
using System.Globalization;
using Rotativa.AspNetCore;
using System.IO;
using System;
using Quote2Invoice.UI.Data;
using Microsoft.EntityFrameworkCore;

namespace Quote2Invoice.UI
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
      services.AddMvc(options =>
      {
        options.Filters.Add(new GlobalExceptionFilter());
        // options.Filters.Add(new RequireHttpsAttribute());
      });

      services.AddDataProtection()
        .PersistKeysToFileSystem(new DirectoryInfo(Environment.CurrentDirectory + "\\keys\\"));

      services.AddAuthentication(Configuration["CookieSecurityScheme"])
        .AddCookie(Configuration["CookieSecurityScheme"], options =>
        {
          options.AccessDeniedPath = new PathString("/authenticate/noaccess");
          options.LoginPath = new PathString("/authenticate/index");
          options.ExpireTimeSpan = new TimeSpan(0, Convert.ToInt32(Configuration["CookieExpireTimeSpan"]), 0);
        });

      services.AddDbContext<SecurityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Quote2Invoice.Security")));

      services.AddTransient<IWebApiCaller, WebApiCaller>();
      services.AddTransient<ICookieHelper, CookieHelper>();
      services.AddTransient<ISecurityHelper, SecurityHelper>();
      services.AddTransient<IUserAgentHelper, UserAgentHelper>();
      services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      var cultureInfo = new CultureInfo("en-US");
      cultureInfo.NumberFormat.CurrencySymbol = "R";

      CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
      CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

      RotativaConfiguration.Setup(env);

      if (env.IsDevelopment())
      {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseAuthentication();
      app.UseStaticFiles();
      app.UseMvc(routes =>
      {
        routes.MapRoute(
           name: "default",
           template: "{controller=authenticate}/{action=index}/{id?}");
      });

    }
  }
}
