﻿using System;

namespace RockLib.Messaging.Example.Core
{
    class Program
    {
        // using project reference for now, will change to nuget once we get Messaging Stable
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           
            var namedPipeProducer = MessagingScenarioFactory.CreateQueueProducer("Pipe1");
            var namedPipeConsumer = MessagingScenarioFactory.CreateQueueConsumer("Pipe1");

            namedPipeConsumer.Start();
            namedPipeConsumer.MessageReceived += (sender, eventArgs) =>
            {
                var eventArgsMessage = eventArgs.Message;
                var message = eventArgsMessage.GetStringValue();
                
                Console.WriteLine($"Message: {message}");
            };

            namedPipeProducer.Send("Test Named Pipe Message");
        }
    }
    
}
