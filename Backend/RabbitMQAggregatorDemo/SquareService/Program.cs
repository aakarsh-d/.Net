using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Shared;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare("calc_exchange", ExchangeType.Fanout);

channel.QueueDeclare("square_queue", false, false, false, null);
channel.QueueBind("square_queue", "calc_exchange", "");

channel.QueueDeclare("result_queue", false, false, false, null);

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
    var msg = JsonSerializer.Deserialize<InputMessage>(json);

    int result = msg.Value * msg.Value;

    var output = new ResultMessage
    {
        CorrelationId = msg.CorrelationId,
        Type = "square",
        Value = result
    };

    var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(output));

    channel.BasicPublish("", "result_queue", null, body);

    Console.WriteLine($"Square: {msg.Value}^2 = {result}");
};

channel.BasicConsume("square_queue", true, consumer);

Console.ReadLine();