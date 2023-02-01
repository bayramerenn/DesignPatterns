

using CommandPattern.Sample3.Command;
using CommandPattern.Sample3.Invoke;
using CommandPattern.Sample3.Revicer;

WindowsFileSystemReceiver reciver = new WindowsFileSystemReceiver();

OpenFileCommand command = new OpenFileCommand(reciver);

var invoker = new FileInvoker();
invoker.SetCommand(command);
invoker.Invoke();

WriteFileCommand writeFileCommand = new WriteFileCommand(reciver);
invoker.SetCommand(writeFileCommand);
invoker.Invoke();




