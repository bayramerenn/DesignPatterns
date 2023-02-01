using CommandPattern.Sample3.Revicer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Sample3.Command
{
    public class CloseFileCommand : ICommand
    {
        private readonly IFileSystemReciver _fileSystemReceiver;

        public CloseFileCommand(IFileSystemReciver fileSystemReceiver)
        {
            _fileSystemReceiver = fileSystemReceiver;
        }

        public void Execute()
        {
            _fileSystemReceiver.CloseFile();
        }
    }
}
