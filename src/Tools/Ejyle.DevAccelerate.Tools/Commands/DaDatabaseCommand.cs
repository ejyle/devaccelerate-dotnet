using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejyle.DevAccelerate.Tools.Commands
{
    public abstract class DaDatabaseCommand : IDaCommand
    {
        [Option('c', "connectionstring", Required = false, HelpText = "Connection string of the DevAccelerate database")]
        public string ConnectionString { get; set; } = @"Data Source=(localdb)\mssqllocaldb; Initial Catalog=DevAccelerate; Integrated Security=True;";

        public abstract void Execute();
    }
}
