/*
 PRODUCER!
 */
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQClient;
using System.Text;

var factory = new ConnectionFactory { HostName = "", UserName = "writer-stg", Password= "" };//IP Address from RabbitMQ server
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

string json = JsonConvert.SerializeObject(new Serial());
var body = Encoding.UTF8.GetBytes(json);

channel.BasicPublish(exchange: "jemsmm.exchange",
    routingKey:"",
    basicProperties: null,
    body: body);
Console.WriteLine($" [x] Sent {json}");
Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();