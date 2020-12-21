using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AdminLte3.Data;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Framework.DependencyInjection;
using NToastNotify;

namespace AdminLte3
{
    public class Startup
    {
        private CultureInfo[] supportedCultures;
        private RequestCulture defaultCulture;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            supportedCultures = new[]
                {
                    new CultureInfo("en"),
                    new CultureInfo("fa")
                };
            defaultCulture = new RequestCulture("fa");
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //services.AddAutoMapper(x=> x.);
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddControllers();
            services.AddDbContext<TodosContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("TodosContext")));
            services.AddLocalization();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = defaultCulture;
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            services.AddControllersWithViews(options =>
            {
                options.AddFlagsEnumModelBinderProvider();
            })
               .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
               .AddDataAnnotationsLocalization(options =>
               {
                   options.DataAnnotationLocalizerProvider = (type, factory) =>
                       factory.Create(typeof(SharedResources));
               }).AddNToastNotifyToastr(new ToastrOptions()
               {
                   ProgressBar = false,
                   PositionClass = ToastPositions.BottomCenter
               });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = defaultCulture,
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseMvcWithDefaultRoute().UseStaticFiles();
        }
    }
}
