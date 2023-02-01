using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Sample3.Revicer
{
    public class UnixFileSystemReceiver : IFileSystemReciver
    {
        public void CloseFile()
        {
            Console.WriteLine("Closing file in unix Os");
        }

        public void OpenFile()
        {
            Console.WriteLine("Opening file in unix Os");
        }

        public void WriteFile()
        {
            Console.WriteLine("Writing file in unix Os");
        }
    }
}
