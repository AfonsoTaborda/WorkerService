using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WorkerService1.DbContextInit;
using WorkerService1.Models;
using WorkerService1.Work;

namespace WorkerService1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        private readonly IServiceScopeFactory _serviceScopeFactory;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    try
                    {
                        var _dbContext = services.GetRequiredService<DataAccessContext>();
                        var retrieveAndPopulate = new RetrieveAndPopulateDatabase();
                        var microcontrolers = _dbContext.MicrocontrollerModels.ToList();
                        foreach (var item in microcontrolers)
                        {
                            var result = retrieveAndPopulate.UpdateDatabase(item);

                            _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ValuesModels] ON");

                            _dbContext.ValuesModels.Add(result);
                            _dbContext.SaveChanges();

                            _dbContext.Database.ExecuteSqlRaw("SET IDENTITY_INSERT [dbo].[ValuesModels] OFF");

                            _logger.LogInformation("Result Added: {result}", result?.ToString());
                        }
                        await _dbContext.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred while seeding the database.");
                    }
                }
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await Task.Delay(60*1000, stoppingToken);
            }
        }
    }
}
