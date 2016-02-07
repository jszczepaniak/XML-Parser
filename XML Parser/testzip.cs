using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ionic.Zip;

namespace XML_Parser
{
    class testzip
    {
        private ZipFile zip;
        void test()
        {
            zip = ZipFile.Read("a");
        }
    }
}
