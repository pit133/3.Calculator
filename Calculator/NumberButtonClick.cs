using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private void NumberButtonAction(string parameter)
        {
            if (_result.Length <= 9)
            {
                if (_isOperationPending)
                {
                    _currentOperand = string.Empty;
                    _lastOperand = string.Empty;
                    _isOperationPending = false;
                }

                if (_currentOperand == "0")
                {
                    _currentOperand = parameter;
                    _lastOperand = parameter;
                }
                else
                {
                    _currentOperand += parameter;
                    _lastOperand += parameter;
                }

                Result = _currentOperand;

            }
        }
    }
}
