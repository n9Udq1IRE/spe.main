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
            Identity __identity = new Identity();
            __identity.save();
        }
    }
}
