using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MacNote
{
    public class MyICommand : ICommand
    {
        Action _TargetExecutedMethod;
        Func<bool> _TargetCanExecuteMethod;

        public MyICommand(Action executeMethod)
        {
            _TargetExecutedMethod = executeMethod;
        }
        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecutedMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
            {
                return _TargetCanExecuteMethod();
            }
            if (_TargetExecutedMethod != null)
                return true;

            return false;
        }



        public event EventHandler CanExecuteChanged = delegate { };



        void ICommand.Execute(object parameter)
        {
            if (_TargetExecutedMethod != null)
                _TargetExecutedMethod();
        }
    }
}
