using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RemoteCompile
{
    class Program
    {
        static void Main(string[] args)
        {
            var vmfPath = "";
            var configPath = Path.Combine("<executing assembly file location>", "remotecompile.cfg");

            //TODO: Take parameter of map to compile
            //TODO: Take optional parameter of config file path
            //TODO: Load local config file, if it doesn't exist, create a default one

            if (File.Exists(configPath))
            {
                //TODO: Load config
            }
            else
            {
                //TODO: Create default config
            }

            //TODO: Load VMF

            //TODO: Recursively identify and load dependent instances
            //      Track instance dependency tree to recognize instance recursion
            //      Only dig 100 levels deep unless otherwise specified in the config

            //TODO: Request hashes of all dependent resources from server.
            //      Compare results to local copies.
            //      Notify user of the comparison


            //TODO: Send compile request with serialized parameters, and list of incoming resources

            //TODO: Send copy of vmf and instances to server

            //TODO: Spin off waiting thread for server to execute OnCompleteBuild commands
            //      This could include: downloading the map, and running the game

        }
    }
}
