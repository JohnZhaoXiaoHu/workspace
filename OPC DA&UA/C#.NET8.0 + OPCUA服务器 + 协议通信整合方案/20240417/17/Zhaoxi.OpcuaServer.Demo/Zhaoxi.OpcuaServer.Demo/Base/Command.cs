using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Zhaoxi.OpcuaServer.Demo.Base
{
    internal class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action?.Invoke(parameter);
        }

        Action<object> action;
        public Command(Action<object> a)
        {
            action = a;
        }
    }
}
