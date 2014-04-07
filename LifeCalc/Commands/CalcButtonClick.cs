using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LifeCalc.Commands
{
    public class CalcButtonClick : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public event EventHandler CanExecuteChanged;
    }
}
