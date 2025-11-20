using RabbitMQ.Client;
using System.Text;

namespace MyApp.Api.Services;

public class PublisherService
{
    private readonly ConnectionFactory _factory;

    public PublisherService()
    {
        _factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };
    }

    public void Send(string message)
    {
        using var connection = _factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(
            queue: "myqueue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);

        var body = Encoding.UTF8.GetBytes(message);

        channel.BasicPublish(
            exchange: "",
            routingKey: "myqueue",
            basicProperties: null,
            body: body);
    }
}

















// using RabbitMQ.Client;
// using System.Text;

// namespace MyApp.Api.Services;

// public class PublisherService
// {
//     private readonly ConnectionFactory _factory;

//     public PublisherService()
//     {
//         _factory = new ConnectionFactory()
//         {
//             HostName = "localhost",
//             UserName = "guest",
//             Password = "guest"
//         };
//     }

//     public void Send(string message)
//     {
//         using var connection = _factory.CreateConnection();
//         using var channel = connection.CreateModel();

//         channel.QueueDeclare(
//             queue: "myqueue",
//             durable: false,
//             exclusive: false,
//             autoDelete: false,
//             arguments: null);

//         var body = Encoding.UTF8.GetBytes(message);

//         channel.BasicPublish(
//             exchange: "",
//             routingKey: "myqueue",
//             basicProperties: null,
//             body: body);
//     }
// }