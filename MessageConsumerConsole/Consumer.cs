// See https://aka.ms/new-console-template for more information
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;

Console.WriteLine("Hello, World!");

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "guest",
    Password = "guest"
};

var _connection = factory.CreateConnection();

var _channel = _connection.CreateModel();

//_channel.ExchangeDeclare("forecast_exchange", ExchangeType.Direct);
_channel.QueueDeclare("test_queue", true, false, false, null);
// _channel.QueueBind("test_queue", "forecast_exchange", "test_queue");

var consumer = new EventingBasicConsumer(_channel);

consumer.Received += (ch, ea) =>
{
    // received message
    var content = Encoding.UTF8.GetString(ea.Body.ToArray());
    if (content != null)
    {
        Console.WriteLine(content);
    }

    // handle the received message
    _channel.BasicAck(ea.DeliveryTag, false);
};

_channel.BasicConsume("test_queue", false, consumer);

Console.ReadLine();