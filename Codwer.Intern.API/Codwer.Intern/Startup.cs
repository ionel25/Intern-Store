using Codwer.Intern.Application.Authors.Services;
using Codwer.Intern.Application.Authors.Services.Implementations;
using Codwer.Intern.Application.Books.Services;
using Codwer.Intern.Application.Books.Services.Implementations;
using Codwer.Intern.Application.Covers.Services;
using Codwer.Intern.Application.Covers.Services.Implementations;
using Codwer.Intern.Application.Editions.Services;
using Codwer.Intern.Application.Editions.Services.Implementations;
using Codwer.Intern.Application.Languages.Services;
using Codwer.Intern.Application.Languages.Services.Implementations;
using Codwer.Intern.Application.PartnerPrices.Services;
using Codwer.Intern.Application.PartnerPrices.Services.Implementations;
using Codwer.Intern.Application.Types.Services;
using Codwer.Intern.Application.Types.Services.Implementations;
using Codwer.Intern.Persistence.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Codwer.Intern
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
            services.AddControllers();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICoverService, CoverService>();
            services.AddTransient<IEditionService, EditionService>();
            services.AddTransient<ILanguageService, LanguageService>();
            services.AddTransient<IPartnerPricesService, PartnerPricesService>();
            services.AddTransient<ITypeService, TypeService>();

            services.AddDbContext<AppDbContext>();

            services.AddRazorPages();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });

            services.AddMvcCore()
                .AddApiExplorer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext appDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(c => c.MapControllers());

        }

    } 
}
