using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Sample3.Revicer
{
    public interface IFileSystemReciver
    {
        void OpenFile();
        void WriteFile();
        void CloseFile();
    }
}
