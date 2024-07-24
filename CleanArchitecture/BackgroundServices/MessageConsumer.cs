
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
        private readonly ILogger<MessageConsumer> _logger;
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var factory = new ConnectionFactory
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest"
                };

                // create connection
                var _connection = factory.CreateConnection();

                // create channel
                var _channel = _connection.CreateModel();

                //_channel.ExchangeDeclare("forecast_exchange", ExchangeType.Direct);
                _channel.QueueDeclare("test_queue", true, false, false, null);
               // _channel.QueueBind("test_queue", "forecast_exchange", "test_queue");

                var consumer = new EventingBasicConsumer(_channel);

                consumer.Received += (ch, ea) =>
                {

                    // received message
                    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                    if(content != null)
                    {
                        Debug.WriteLine(content);
                        //_logger.LogInformation("test_queue data => " + content.ToString());
                    }

                    // handle the received message
                    _channel.BasicAck(ea.DeliveryTag, false);
                };


                _channel.BasicConsume("test_queue", false, consumer);

            }

        }
    }
}
