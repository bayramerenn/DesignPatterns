using CommandPattern.Sample3.Command;

namespace CommandPattern.Sample3.Invoke
{
    public class FileInvoker
    {
        private ICommand _command;

        public void SetCommand(ICommand command) => _command = command;
        public void Invoke()
        {
            _command.Execute();
        }
    }
}