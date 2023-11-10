using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost", Port = 6000 };

using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.ExchangeDeclare(exchange: "topic_logs", type: ExchangeType.Topic);

var routingKey = "hello.pdf";
var message = "Hello";
var body = Encoding.UTF8.GetBytes(message);
channel.BasicPublish(exchange: "topic_logs",
                     routingKey: routingKey,
                     basicProperties: null,
                     body: body);
Console.WriteLine($" [x] Sent '{routingKey}':'{message}'");