using System;
using System.Collections.Generic;

namespace Falcon.CLI.Commands.Impl
{
    public class UpdateZipCommand : ICommand
    {
        public void Run()
        {
            Console.WriteLine("Updating database from csv...");

            Console.WriteLine("Update Completed Successfully");
        }

        public IList<string> Parameters
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}