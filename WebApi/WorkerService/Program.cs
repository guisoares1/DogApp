using WorkerService;
using Hangfire;
using Hangfire.SqlServer;
using Domain.Services;
using CrossCutting.DI;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(context.Configuration.GetConnectionString("ConnectionServer")));

        services.AddHangfire(config =>
            config.UseSqlServerStorage(context.Configuration.GetConnectionString("DefaultConnection")));

        services.AddHangfireServer();
        services.AddDependencies();
        services.AddTransient<IRecurringJobManager, RecurringJobManager>();
    });

var host = builder.Build();

using (var scope = host.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider.GetRequiredService<IRecurringJobManager>();
    recurringJobManager.AddOrUpdate<DogService>(
        "fetch-and-store-breeds",
        job => job.FetchAndStoreBreeds(),
        Cron.Hourly);
}

host.Run();
