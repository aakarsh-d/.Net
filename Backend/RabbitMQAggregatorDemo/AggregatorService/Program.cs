using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Shared;

var factory = new ConnectionFactory() { HostName = "localhost" };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare("result_queue", false, false, false, null);

var store = new Dictionary<string, (int? square, int? cube)>();

var consumer = new EventingBasicConsumer(channel);

consumer.Received += (model, ea) =>
{
    var json = Encoding.UTF8.GetString(ea.Body.ToArray());
    var msg = JsonSerializer.Deserialize<ResultMessage>(json);

    if (!store.ContainsKey(msg.CorrelationId))
        store[msg.CorrelationId] = (null, null);

    var entry = store[msg.CorrelationId];

    if (msg.Type == "square")
        entry.square = msg.Value;
    else if (msg.Type == "cube")
        entry.cube = msg.Value;

    store[msg.CorrelationId] = entry;

    Console.WriteLine($"Received {msg.Type}: {msg.Value}");

    if (entry.square.HasValue && entry.cube.HasValue)
    {
        int result = entry.square.Value + entry.cube.Value;

        Console.WriteLine($"FINAL RESULT: {result}");

        store.Remove(msg.CorrelationId);
    }
};

channel.BasicConsume("result_queue", true, consumer);

Console.ReadLine();