using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace CorrelationDemo.Controllers
{
        [ApiController]
        [Route("[controller]")]
        public class NumberController : ControllerBase
        {
            [HttpGet]
            public async Task<string> SendNumber(int number)
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost"
                };

                await using var connection = await factory.CreateConnectionAsync();
                await using var channel = await connection.CreateChannelAsync();

                // create queues
                await channel.QueueDeclareAsync("number_queue", false, false, false);
                await channel.QueueDeclareAsync("result_queue", false, false, false);

                var correlationId = Guid.NewGuid().ToString();

                var props = new BasicProperties();
                props.CorrelationId = correlationId;
                props.ReplyTo = "result_queue";

                var body = Encoding.UTF8.GetBytes(number.ToString());

                await channel.BasicPublishAsync(
        exchange: "",
        routingKey: "number_queue",
        mandatory: false,
        basicProperties: props,
        body: body);

                string result = "";

                var consumer = new AsyncEventingBasicConsumer(channel);

                consumer.ReceivedAsync += async (sender, ea) =>
                {
                    if (ea.BasicProperties.CorrelationId == correlationId)
                    {
                        result = Encoding.UTF8.GetString(ea.Body.ToArray());
                    }

                    await Task.CompletedTask;
                };

                await channel.BasicConsumeAsync(
                    queue: "result_queue",
                    autoAck: true,
                    consumer: consumer);

                while (result == "")
                    await Task.Delay(100);

                return "Final Cube Result = " + result;
            }
        }
}