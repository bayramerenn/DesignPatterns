using CommandPattern.Sample3.Revicer;

namespace CommandPattern.Sample3.Command
{
    public class WriteFileCommand : ICommand
    {
        private IFileSystemReciver _fileSystemReceiver;

        public WriteFileCommand(IFileSystemReciver fileSystemReceiver)
        {
            _fileSystemReceiver = fileSystemReceiver;
        }

        public void Execute()
        {
            _fileSystemReceiver.WriteFile();
        }
    }
}