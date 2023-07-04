/*
 Messages PRODUCER!
 */
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQClient;
using System.Text;



#region Producer
var factory = new ConnectionFactory { 
    HostName = "10.59.4.24", //IP Address from RabbitMQ server (MXMTYM1OPSWEB81)
    UserName = "spider_ems", 
    Password = "spider" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

for (int i = 0; i < 100; i++)
{
    //Passed
    #region Passed
    string json = JsonConvert.SerializeObject(Message.GetPassed());
    var body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER001",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine(json);
    Console.WriteLine("=================================================================");
    Console.WriteLine("Nuevo Mensaje enviado");
    Console.WriteLine($" [x] Longitud del mensaje: {json.Length}");
    Console.WriteLine("=================================================================");
    #endregion

    //New Unit
    #region New Unit
    json = JsonConvert.SerializeObject(Message.GetNewUnitMessage());
    body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER001",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine("=================================================================");
    Console.WriteLine("Nuevo Mensaje enviado");
    Console.WriteLine($" [x] Sent {json}");
    Console.WriteLine("=================================================================");
    #endregion

    //New Unit Identied
    #region New Unit Identied
    json = JsonConvert.SerializeObject(Message.GetUnitIdentied());
    body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER001",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine("=================================================================");
    Console.WriteLine("Nuevo Mensaje enviado");
    Console.WriteLine($" [x] Sent {json}");
    Console.WriteLine("=================================================================");
    #endregion

    //New Failed
    #region New Failed
    json = JsonConvert.SerializeObject(Message.GetFailed());
    body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER001",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine("=================================================================");
    Console.WriteLine("Nuevo Mensaje enviado");
    Console.WriteLine($" [x] Sent {json}");
    Console.WriteLine("=================================================================");
    #endregion

    //New Unit with error
    #region New unit with error
    json = JsonConvert.SerializeObject(Message.GetUnitWithError());
    body = Encoding.UTF8.GetBytes(json);

    channel.BasicPublish(exchange: "spider",
        routingKey: "PCSPIDER001",//Hostname of machine
        basicProperties: null,
        body: body);
    Console.WriteLine("=================================================================");
    Console.WriteLine("Nuevo Mensaje enviado");
    Console.WriteLine($" [x] Sent {json}");
    Console.WriteLine("=================================================================");
    #endregion

    Console.WriteLine("\n\nMensajes enviados: 5");
    Thread.Sleep(1000);//Delay de 1 segundo
}

#endregion


Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();