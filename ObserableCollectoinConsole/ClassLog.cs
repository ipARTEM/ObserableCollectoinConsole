using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserableCollectoinConsole
{
    class ClassLog
    {
        static List<string> vs = new List<string>();

        public static void Log(string str)
        {
            vs.Add(str);
        }

    }
}
