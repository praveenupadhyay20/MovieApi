namespace MovieApi.Job
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using MovieApi.Database;
    using MovieApi.Entity;
    using MovieApi.Repositories;
    using System;
    using System.Numerics;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public Worker(IServiceScopeFactory scopeFactory, ILogger<Worker> logger)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (IsTimeToGenerateReport())
                {
                    try
                    {
                        using (var scope = _scopeFactory.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var dbContext = scopedServices.GetRequiredService<AppDbContext>();

                            var report = await GenerateDailyReport(dbContext);
                            PublishReport(report);

                            _logger.LogInformation("Daily report generated and published successfully.");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error occurred while generating or publishing the daily report.");
                    }
                }

                // Wait for the next iteration
                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }

        private bool IsTimeToGenerateReport()
        {
            return DateTime.Now.TimeOfDay >= new TimeSpan(8, 0, 0); // Generate report at 8:00 AM every day
        }

        public async Task<string> GenerateDailyReport(AppDbContext dbContext)
        {
            var report = new StringBuilder();
            var allActors = await dbContext.Actors.ToListAsync();
            report.Append("Daily Report:\n");

            foreach (var actor in allActors)
            {

                report.AppendLine($"Actor:{actor.Name}");
                report.AppendLine($"Count of Movies:{actor.Movies.Count()}");
            }

            var allMovies = await dbContext.Movies.ToListAsync();
            var allGenre = await dbContext.Genres.ToListAsync();
            report.AppendLine($"Count of Different Genres:{allGenre}");

            foreach (var movieGenre in allMovies.GroupBy(x => x.Genres))
            {


                report.AppendLine($"Movie Count by Genres:{movieGenre.Key} - {movieGenre.Count()}");
            }

            return report.ToString();
        }

        private void PublishReport(string report)
        {
            // Logic to publish the report
            Console.WriteLine(report);
        }
    }

}
