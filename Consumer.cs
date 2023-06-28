using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQClient
{
    public  class Consumer
    {
        public string RoutingKey { get; set; }
        public Consumer(string routingKey)
        {
            RoutingKey = routingKey;
        }
        
        public void DoWork()
        {
            var factory = new ConnectionFactory
            {
                HostName = "10.59.4.24",
                UserName = "spider_ems",
                Password = "spider",
                AutomaticRecoveryEnabled = true
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            string queue = channel.QueueDeclare().QueueName;
            channel.QueueBind(queue: queue,
             exchange: "spider",
             routingKey: RoutingKey);
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($" [x] Received {message}");
            };
            string consumerTag = channel.BasicConsume(queue, autoAck: true, consumer);
            Console.WriteLine("Press any key to quit");
            Console.ReadKey();
            // Cleanup.
            channel.BasicCancel(consumerTag);
            channel.Close();
            connection.Close();
        }
    }
}
