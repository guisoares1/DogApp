using Hangfire;
using Hangfire.SqlServer;
using Domain.Services;
using CrossCutting.DI;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;



var builder = Host.CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(webBuilder =>
    {
        webBuilder.ConfigureServices((context, services) =>
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(context.Configuration.GetConnectionString("ConnectionServer")));

            services.AddHangfire(config =>
                config.UseSqlServerStorage(
                    context.Configuration.GetConnectionString("DefaultConnection"),
                    new SqlServerStorageOptions
                    {
                        PrepareSchemaIfNecessary = true
                    }
                )
            );

            services.AddHangfireServer();
            services.AddDependencies();
            services.AddTransient<IRecurringJobManager, RecurringJobManager>();
        });

        webBuilder.Configure(app =>
        {
            app.UseHangfireDashboard("/hangfire");
        });
    });

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var jobStorage = scope.ServiceProvider.GetRequiredService<JobStorage>();

    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
    recurringJobManager.AddOrUpdate<DogService>(
        "fetch-and-store-breeds",
        job => job.FetchAndStoreBreeds(),
        Cron.Hourly);
}


host.Run();
