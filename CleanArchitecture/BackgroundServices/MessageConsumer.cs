
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Azure;
using CleanArchitecture.Application.Common.Behaviors;
using System.Diagnostics;

namespace CleanArchitecture.Api.BackgroundServices
{
    public class MessageConsumer() : BackgroundService, IHostedService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    if (10 % 3 == 0) Debug.WriteLine("aaaaaa");
            //}

        }
    }
}
