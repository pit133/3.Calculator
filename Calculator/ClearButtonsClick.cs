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
            _exOperand = string.Empty;
            Result = "0";
        }

        public void BackSpace()
        {
            if (_currentOperand.Length == 1) 
            {
                _currentOperand = "0";
                Result = "0";
            }
            else if (_currentOperand != string.Empty)
            {
                _currentOperand = _currentOperand.Substring(0, _currentOperand.Length - 1);
                Result = Result.Substring(0, Result.Length - 1);
            }
        }
    }
}
