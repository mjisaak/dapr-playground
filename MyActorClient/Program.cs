using System;
using System.Threading.Tasks;
using Dapr.Actors;
using Dapr.Actors.Client;
using MyActor.Interfaces;

namespace MyActorClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            InvokeActorMethodWithRemotingAsync().GetAwaiter().GetResult();

        }

        static async Task InvokeActorMethodWithRemotingAsync()
        {
            var actorType = "MyActor";      // Registered Actor Type in Actor Service
            var actorID = new ActorId("1");

            // Create the local proxy by using the same interface that the service implements
            // By using this proxy, you can call strongly typed methods on the interface using Remoting.
            var proxy = ActorProxy.Create<IMyActor>(actorID, actorType);
            var response = await proxy.SetDataAsync(new MyData()
            {
                PropertyA = "ValueA",
                PropertyB = "ValueB",
            });
            Console.WriteLine(response);

            var savedData = await proxy.GetDataAsync();
            Console.WriteLine(savedData);
        }
    }
}
