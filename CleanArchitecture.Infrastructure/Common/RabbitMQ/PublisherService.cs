using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Common.RabbitMQ
{
    public class PublisherService : IPublisherService
    {
        private readonly IRabbitMQService _rabbitMQService;
        public PublisherService(IRabbitMQService rabbitMQService)
        {
            _rabbitMQService = rabbitMQService;
        }

        public void Enqueue<T>(IEnumerable<T> queueDataModels, string queueName,string exchangeName,string exchangeType,string routingKey) where T : class, new()
        {
            using (var connection = _rabbitMQService.GetConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                if(exchangeName != null)
                {
                    channel.ExchangeDeclare(exchange: exchangeName,
                                        exchangeType,
                                        durable: true,
                                        autoDelete: false,
                                        arguments: null);

                    channel.QueueBind(queueName, exchangeName, queueName ?? routingKey ?? "", null);
                }

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.Expiration = (1000 * 60 * 60 * 2).ToString();

                foreach(var queueDataModel in queueDataModels)
                {
                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(queueDataModel));
                    channel.BasicPublish(exchange: exchangeName ?? "",
                                         routingKey: queueName ?? routingKey ?? "",
                                         basicProperties: properties,
                                         body: body);
                    
                }
            }

        }
    }
}
