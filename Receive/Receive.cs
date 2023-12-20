using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new EventingBasicConsumer(channel);
var totalReceived = 0;
consumer.Received += (model, ea) =>
{
  var body = ea.Body.ToArray();
  var message = Encoding.UTF8.GetString(body);
  totalReceived++;
  var totalReceivedWithPadding = totalReceived.ToString().PadLeft(4, '0');
  Console.WriteLine($" [x] Received {message} - {totalReceivedWithPadding}");
};
channel.BasicConsume(queue: "hello",
                     autoAck: true,
                     consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();
