using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AccountantAppWebAPI
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
			var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");

			services.AddDbContext<ApplicationContext>(opt =>
				opt.UseNpgsql(connectionString));

			services.AddTransient<IWalletService, WalletService>();
			services.AddTransient<IAccountService, AccountService>();
			services.AddTransient<IOperationService, OperationService>();

			services.AddAutoMapper(typeof(Startup));

			services.AddControllers();

			services.AddCors(opt =>
			{
				opt.AddDefaultPolicy(
					builder =>
					{
						builder.WithOrigins("http://localhost:3000")
							.AllowAnyHeader()
							.AllowAnyMethod();
					});
			});

			services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Services", Version = "v1"}); });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Services v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors();

			app.UseAuthorization();

			app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
			
			using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
			{
				var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
				context.Database.EnsureCreated();
			}
		}
	}
}
