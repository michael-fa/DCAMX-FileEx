using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AMXWrapper;
using dcamx;

namespace dcamx
{
    public class Plugin
    {

        public static string[] NativeList = { "IOEX_CreateFolder", "IOEX_DeleteFolder", "IOEX_CreateFile", "IOEX_CopyFile"};
        public Plugin()
        {
            dcamx.Utils.Log.Info("IO Extension Plugin loading..");
           
        }

        public static string[] GetNatives()
        {
            return NativeList;
        }

        public void OnLoad()
        {
            dcamx.Utils.Log.Info("IO Extension Plugin loaded");
        }



        public void OnUnload(int exitcode)
        {

            dcamx.Utils.Log.Info("  > IO Extension Plugin unloaded.");
        }

        public int IOEX_CreateFolder(AMX amx1, AMXArgumentList args1)
        {
            if (args1.Length != 1) return 0;
            if (args1[0].AsString().Length == 0) return 0;
            Directory.CreateDirectory(System.AppContext.BaseDirectory + args1[0].AsString());
            return 1;
        }

        public int IOEX_DeleteFolder(AMX amx1, AMXArgumentList args1)
        {
            if (args1.Length != 1) return 0;
            if (args1[0].AsString().Length == 0) return 0;
            Directory.Delete(System.AppContext.BaseDirectory + args1[0].AsString());
            return 1;
        }

        public int IOEX_CreateFile(AMX amx1, AMXArgumentList args1)
        {
            if (args1.Length != 1) return 0;
            if (args1[0].AsString().Length == 0) return 0;
            File.Create(System.AppContext.BaseDirectory + args1[0].AsString());
            return 1;
        }

        public int IOEX_CopyFile(AMX amx1, AMXArgumentList args1)
        {
            if (args1.Length != 2) return 0;
            if (args1[0].AsString().Length == 0 || args1[1].AsString().Length == 0) return 0;
            if (!File.Exists(args1[0].AsString())) return 0;
            File.Copy(args1[0].AsString(), args1[1].AsString());
            return 1;
        }
    }
}
