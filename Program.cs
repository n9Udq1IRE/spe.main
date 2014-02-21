using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace spe.main
{
    class Program
    {
        static void Main(string[] args)
        {
            int __index = 0;
            while (__index < 1)
            {
                Identity __identity = new Identity();
                __identity.save();
                __index++;
            }
        }
    }
}
