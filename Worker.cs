using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MyService
{
    public class Worker : BackgroundService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ILogger<Worker> _logger;

        public Worker(IHostApplicationLifetime hostApplicationLifetime, ILogger<Worker> logger)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("上班了，又是精神抖擞的一天，StartAsync ");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    try
                    {
                        _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                        await SomeMethodThatDoesTheWork(stoppingToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Global exception occurred. Will resume in a moment.");
                    }

                    await Task.Delay(TimeSpan.FromSeconds(2), stoppingToken);
                }
            }
            finally
            {
                _logger.LogCritical("Exiting application...");
                GetOffWork(stoppingToken);
                _hostApplicationLifetime.StopApplication();
            }
        }

        private async Task SomeMethodThatDoesTheWork(CancellationToken cancellationToken)
        {
            Console.WriteLine("我爱工作，埋头苦干ing……");
            await Task.CompletedTask;
        }

        private void GetOffWork(CancellationToken cancellationToken)
        {
            Console.WriteLine("不行，我爱加班，我要再干 20 秒，ExecuteAsync 111 ");

            Task.Delay(TimeSpan.FromSeconds(20)).Wait();

            Console.WriteLine("不行，我爱加班，我要再干 10 秒，ExecuteAsync 222 ");

            Task.Delay(TimeSpan.FromSeconds(10)).Wait();

            Console.WriteLine("不行，我爱加班，我要再干 1 分钟，ExecuteAsync 333 ");

            Task.Delay(TimeSpan.FromMinutes(1)).Wait();
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("下班时间到了，StopAsync ");
            // Task.Delay(3000);
            return base.StopAsync(cancellationToken);
        }
    }
}