using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using Shared;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare("calc_exchange", ExchangeType.Fanout);

Console.Write("Enter value of a: ");
int a = int.Parse(Console.ReadLine());

var message = new InputMessage
{
    CorrelationId = Guid.NewGuid().ToString(),
    Value = a
};

var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

channel.BasicPublish("calc_exchange", "", null, body);

Console.WriteLine($"Sent a={a}, CorrelationId={message.CorrelationId}");