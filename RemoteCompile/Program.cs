using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using VMFParser;
using Config = VMFParser.VMF;

namespace RemoteCompile
{
    class Program
    {

        static void Main(string[] args)
        {
#if DEBUG
            var vmfPath = @".\..\..\Tests\dev_room.vmf";
            var configPath = @".\..\..\Tests\remotecompile.cfg";
#else
            var vmfPath = "path.vmf";
            var configPath = Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location), "remotecompile.cfg");
#endif
            //TODO: Take parameter of map to compile
            //TODO: Take optional parameter of config file path
            //TODO: Load local config file, if it doesn't exist, create a default one

            Config config;
            if (File.Exists(configPath))
            {
                //TODO: Load config
            }
            else
            {
                #region Create default config
                config = new Config(new List<IVNode>
                {
                new VBlock("RemoteCompileConfig", new List<IVNode>
                {
                    new VBlock("BuildServer", new List<IVNode>
                    {
                        new VProperty("Address","127.0.0.1")
                       ,new VProperty("Port","9043")
                       ,new VProperty("Username","")
                       ,new VProperty("Password","")
                       ,new VBlock("AuthLock",new List<IVNode>
                       {
                           new VProperty("Token","")
                          ,new VProperty("Expires","")
                       })
                    })
                   ,new VProperty("BuildTarget","Source SDK 2013")
                   
                   //TODO: Add all available VBSP, VVIS, VRAD parameters
                   ,new VBlock("VBSP", new List<IVNode>
                   {
                       new VProperty("","")
                   })
                   ,new VBlock("VVIS", new List<IVNode>
                   {
                       new VProperty("","")
                   })
                   ,new VBlock("VRAD", new List<IVNode>
                   {
                       new VProperty("","")
                   })
                })});

                File.WriteAllLines(configPath, config.ToVMFStrings());
                #endregion
            }
            
            // Load VMF
            if (!File.Exists(vmfPath))
            {
                // Early exit
                Console.WriteLine("Map does not exist \"{0}\"", vmfPath);
                return;
            }

            var vmfFileContents = File.ReadAllLines(vmfPath);
            var vmf = new VMF(vmfFileContents);

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
