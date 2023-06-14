
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                            new HelloRequest { Name = "Treinaweb Blog" });
            Console.WriteLine("Saudacao: " + reply.Message);
            Console.WriteLine("Pressione qualquer coisa para sair...");
            Console.ReadKey();


        }
    }
}
