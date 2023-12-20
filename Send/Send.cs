using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

DateTime now = DateTime.Now;
var message = $"Hello World! {now}";
var body = Encoding.UTF8.GetBytes(message);

var totalMessages = 1000;

for (int i = 0; i < totalMessages; i++)
{
  var messageNumberWithPadding = i.ToString().PadLeft(totalMessages.ToString().Length, '0');
  channel.BasicPublish(exchange: string.Empty,
                   routingKey: "hello",
                   basicProperties: null,
                   body: body);
  Console.WriteLine($" [x] Sent {message} - {messageNumberWithPadding}");
  // sleep for 1 second
  // Thread.Sleep(10);
}

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
