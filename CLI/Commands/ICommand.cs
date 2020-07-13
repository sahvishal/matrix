using System.Collections.Generic;

namespace Falcon.CLI.Commands
{
    public interface ICommand
    {
        void Run();
        IList<string > Parameters { get; set; }        
    }
}