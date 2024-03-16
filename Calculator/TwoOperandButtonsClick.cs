using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public void DetectOperation(string operation)
        {
            _isOperationPending = true;

            if (_exOperand != string.Empty)
            {
                Calculate();
            }

            switch (operation)
            {
                case "+":
                    _exOperand = _currentOperand;
                    _lastOperation = "+";
                    break;

                case "-":
                    _exOperand = _currentOperand;
                    _lastOperation = "-";
                    break;

                case "*":
                    _exOperand = _currentOperand;
                    _lastOperation = "*";
                    break;

                case "/":
                    _exOperand = _currentOperand;
                    _lastOperation = "/";
                    break;

                case "x^y":
                    _exOperand = _currentOperand;
                    _lastOperation = "x^y";
                    break;

                case "Mod":
                    _exOperand = _currentOperand;
                    _lastOperation = "Mod";
                    break;

                case "=":
                    _exOperand = _currentOperand;
                    _currentOperand = _lastOperand;
                    break;

                case "lg":                    
                    _lastOperation = "lg";
                    Calculate();
                    break;
            }


        }

        public void Calculate()
        {
            double resultOfOperation;
            switch (_lastOperation)
            {
                case "+":
                    
                    resultOfOperation = Convert.ToDouble(_exOperand) + Convert.ToDouble(_currentOperand);
                    _currentOperand = Convert.ToString(resultOfOperation);
                    _exOperand = string.Empty;
                    Result = _currentOperand;
                    //DetectOperation("+");
                    break;

                case "-":
                    resultOfOperation = Convert.ToDouble(_exOperand) - Convert.ToDouble(_currentOperand);
                    _currentOperand = Convert.ToString(resultOfOperation);
                    _exOperand = string.Empty;
                    Result = _currentOperand;
                    //DetectOperation("-");
                    break;

                case "*":
                    resultOfOperation = Convert.ToDouble(_exOperand) * Convert.ToDouble(_currentOperand);
                    _currentOperand = Convert.ToString(resultOfOperation);
                    _exOperand = string.Empty;
                    Result = _currentOperand;
                    //DetectOperation("*");
                    break;

                case "/":
                    if (_currentOperand != "0")
                    {
                        resultOfOperation = Convert.ToDouble(_exOperand) / Convert.ToDouble(_currentOperand);
                        _currentOperand = Convert.ToString(resultOfOperation);
                        _exOperand = string.Empty;
                        Result = _currentOperand;
                        //DetectOperation("/");
                    }
                    else
                        Result = "Деление на ноль невозможно";
                    break;

                case "x^y":
                    resultOfOperation = Math.Pow(Convert.ToDouble(_exOperand), Convert.ToDouble(_currentOperand));
                    _currentOperand = Convert.ToString(resultOfOperation);
                    _exOperand = string.Empty;
                    Result = _currentOperand;
                    break;

                case "Mod":
                    resultOfOperation = Convert.ToDouble(_exOperand) % Convert.ToDouble(_currentOperand);
                    _currentOperand = Convert.ToString(resultOfOperation);
                    _exOperand = string.Empty;
                    Result = _currentOperand;
                    break;

                case "lg":
                    resultOfOperation = Math.Log10(Convert.ToDouble(_currentOperand));
                    //_isOperationPending = true;
                    _currentOperand = Convert.ToString(resultOfOperation);
                    //_exOperand = string.Empty;
                    Result = _currentOperand;
                    break;


            }
        }
    }
}
