/*
 Messages PRODUCER!
 */
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQClient;
using System.Text;

var factory = new ConnectionFactory { HostName = "10.59.4.24", UserName = "spider_ems", Password= "spider" };//IP Address from RabbitMQ server
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

#region Producer
for (int i = 0; i < 20; i++)
{
    //Passed
    string json = JsonConvert.SerializeObject(Message.GetPassed());
    var body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER002",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine($" [x] Sent {json}");

    //New Unit
    json = JsonConvert.SerializeObject(Message.GetNewUnitMessage());
    body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER002",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine($" [x] Sent {json}");

    //New Unit Identied
    json = JsonConvert.SerializeObject(Message.GetUnitIdentied());
    body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER001",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine($" [x] Sent {json}");

    //New Failed
    json = JsonConvert.SerializeObject(Message.GetFailed());
    body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER002",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine($" [x] Sent {json}");

    //New Unit with error
    json = JsonConvert.SerializeObject(Message.GetUnitWithError());
    body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER001",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine($" [x] Sent {json}");
}

#endregion

#region Consumer

#endregion

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();