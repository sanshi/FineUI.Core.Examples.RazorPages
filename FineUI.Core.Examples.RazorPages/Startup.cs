using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace FineUI.Core.Examples.RazorPages
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
		
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // 运行时调用此方法；在这里把服务注册进容器。
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession();


            // 如果当前为 https 请求，则开启 .AspNetCore.Antiforgery（Cookie） 的 Secure 属性
            services.AddAntiforgery(options =>
            {
                options.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest;
            });


            // 配置请求参数限制
            services.Configure<FormOptions>(x =>
            {
                x.ValueCountLimit = 1024;   // 请求参数的个数限制（默认值：1024）
                x.ValueLengthLimit = 4194304;   // 单个请求参数值的长度限制（默认值：4M, 4194304 = 1024 * 1024 * 4）
            });

            // 添加 FineUI 服务
            services.AddFineUI(Configuration);


            // ASP.NET Core RazorPages 支持
            // AddFineUI 已自动登记 FineUI 专属模型绑定器，以及启用 RazorForms 时所需的过滤器。
            var mvcBuilder = services.AddRazorPages().AddNewtonsoftJson();

            // Razor 运行时编译：改 .cshtml 存盘即生效，开发期用。
            // 发布到服务器时用命令行参数 --RazorRuntimeCompilation=false 关掉，
            // 直接使用编译进程序集的视图，页面首次访问不必再现场编译。
            if (Configuration.GetValue("RazorRuntimeCompilation", true))
            {
                mvcBuilder.AddRazorRuntimeCompilation();
            }



            // ##开始配置##多语言服务##########################
            // 添加多语言服务，并指定多语言资源目录为 Resources
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            // 配置请求语言提供程序
            var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("zh-CN"),
                new CultureInfo("zh-TW"),
                new CultureInfo("en-US")
            };
            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(culture: supportedCultures[0].Name, uiCulture: supportedCultures[0].Name);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                // 自定义请求语言提供器（默认的Cookie格式：.AspNetCore.Culture=c=zh-CN|uic=zh-CN，为了复用之前已经定义过的Cookie：Language=zh_CN）
                options.AddInitialRequestCultureProvider(new MyCustomRequestCultureProvider());
            });

            // 配置视图和数据注解的多语言支持
            mvcBuilder.AddViewLocalization().AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(SharedAnnotationResources));
            });
            // ##结束配置##多语言服务##########################


        }

        // 运行时调用此方法；在这里配置 HTTP 请求管道。
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // 部署在反向代理的子路径下时（例如把 https://站点/demo/ 的请求转发到本应用），
            // 用命令行参数 --PathBase=/demo 告知应用根路径；不设置则表示部署在网站根目录。
            var pathBase = Configuration["PathBase"];
            if (!String.IsNullOrEmpty(pathBase))
            {
                app.UsePathBase(pathBase);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            // 使用请求语言服务
            app.UseRequestLocalization();

            app.UseStaticFiles();
            app.UseSession();

            app.UseRouting();

            // 在授权中间件之前加工 FineUI 回发；登录挑战提前返回302时也能输出JSON跳转命令。
            // 文件和普通业务JSON直接发送，401/403仍按原状态进入回发失败处理。
                        app.UseFineUI();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });



        }
    }
}
