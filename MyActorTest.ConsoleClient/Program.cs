using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using Microsoft.ServiceFabric.Actors.Runtime;
using MyActor.Interfaces;

namespace MyActorTest.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = ActorProxy.Create<IMyActor>(ActorId.CreateRandom(), "fabric://MyActorTest");
            var p2 = ActorProxy.Create<IMyActor>(ActorId.CreateRandom(), "fabric://MyActorTest");
            Thread.Sleep(6000);

            Task<int> countTask1 = p1.GetCountAsync();
            Thread.Sleep(6000);

            Console.WriteLine("Count");

            Thread.Sleep(6000);

        }

        private static async Task<int> MakeMove(
            IMyActor p1,
            IMyActor p2,
            ActorId gameId)
        {
            Random rand = new Random();
            int c = await p1.GetCountAsync();
            await Task.Delay(rand.Next(500, 2000));
            return c;
        }

    }
}
