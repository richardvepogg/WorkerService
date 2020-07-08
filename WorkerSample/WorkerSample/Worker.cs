using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerSample
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("O servi�o est� iniciando.");

            stoppingToken.Register(() => _logger.LogInformation("Tarefa de segundo plano est� parando."));

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Executando a Tarefa: {time}", DateTimeOffset.Now);
                await Task.Delay(1000, stoppingToken);
            }

            _logger.LogInformation("O servi�o est� parando.");

        }
    }
}
