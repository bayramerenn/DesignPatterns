using CommandPattern.Sample3.Revicer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Sample3.Command
{
    public class OpenFileCommand : ICommand
    {
        private IFileSystemReciver _fileSystemReceiver;

        public OpenFileCommand(IFileSystemReciver fileSystemReciver)
        {
            _fileSystemReceiver = fileSystemReciver;
        }

        public void Execute()
        {
            _fileSystemReceiver.OpenFile();
        }
    }
}
