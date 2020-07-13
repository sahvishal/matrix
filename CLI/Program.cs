using System;
using Falcon.CLI.Commands.Impl;

namespace Falcon.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            string command;
            bool exit = false;

            while (!exit)
            {
                Console.Write("FalconShell>");
                command = Console.ReadLine();

                switch (command)
                {
                    case "updatezip":
                        new UpdateZipCommand().Run();
                        break;
                    case "exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
            }
            
        }
    }
}
