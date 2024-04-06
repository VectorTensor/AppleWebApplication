using System.Text;
using Apple.JsonDto;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace Apple.Services;

public class RabbitTestProducer
{
    private IChannel _channel;

    

    public async Task Initialize()
    {
        
        var factory = new ConnectionFactory{HostName = "localhost"};
         var connection = await factory.CreateConnectionAsync();

         _channel = await connection.CreateChannelAsync();

    }

    public async void Produce(AppleFeaturesDto features)
    {

        await _channel.QueueDeclareAsync(queue: "hello",
           durable: false, 
           exclusive:false,
           autoDelete:false,
           arguments:null
            );

        // var body = Encoding.UTF8.GetBytes("hello world prayash");
        string x = JsonConvert.SerializeObject(features);
        var body = Encoding.UTF8.GetBytes(x); 

        await _channel.BasicPublishAsync(exchange:string.Empty, "hello",  body: body );
        
        Console.Write("message send");


    }
    
    
    
    
}