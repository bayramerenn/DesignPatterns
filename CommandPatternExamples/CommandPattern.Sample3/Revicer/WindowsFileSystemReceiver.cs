using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Sample3.Revicer
{
    public class WindowsFileSystemReceiver : IFileSystemReciver
    {
        public void CloseFile()
        {
            Console.WriteLine("Closing file in windows Os");
        }

        public void OpenFile()
        {
            Console.WriteLine("Opening file in windows Os");
        }

        public void WriteFile()
        {
            Console.WriteLine("Writing file in windows Os");
        }
    }
}
