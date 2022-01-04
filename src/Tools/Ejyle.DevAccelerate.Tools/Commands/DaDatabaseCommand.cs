using CommandLine;
using Microsoft.Data.SqlClient;
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

        protected void EnsureConnectionIsValid()
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Coould not connecto to the database {ConnectionString}. More information: {ex.Message}", ex);
            }
        }

        public abstract void Execute();
    }
}
