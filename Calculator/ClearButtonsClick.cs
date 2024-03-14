using Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public void Clear()
        {
            _currentOperand = string.Empty;
            Result = "0";
        }

        public void BackSpace()
        {
            _currentOperand = _currentOperand.Substring(0, _currentOperand.Length - 1);
            Result = Result.Substring(0, Result.Length - 1);
        }
    }
}
