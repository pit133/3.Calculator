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
            double resultOfOperation;

            List<string> oneOperandOperations = new List<string> 
            {
                "lg",
                "ln",
                "sin",
                "cos",
                "tan",
                "!n",
            };

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
                    if (oneOperandOperations.Contains(_lastOperation))
                    {
                        Calculate();
                    }
                    else
                    {
                        _exOperand = _currentOperand;
                        _currentOperand = _lastOperand;
                    }
                    break;

                case "lg":
                    _lastOperation = "lg";                    
                    Calculate();
                    break;

                case "!n":
                    _lastOperation = "!n";
                    Calculate();
                    break;

                case "ln":
                    _lastOperation = "ln";
                    Calculate();
                    break;

                case "floor":
                    _lastOperation = "floor";
                    resultOfOperation = Math.Floor(Convert.ToDouble(_currentOperand));
                    _currentOperand = Convert.ToString(resultOfOperation);
                    Result = _currentOperand;                  
                    break;

                case "ceil":
                    _lastOperation = "ceil";
                    resultOfOperation = Math.Ceiling(Convert.ToDouble(_currentOperand));
                    _currentOperand = Convert.ToString(resultOfOperation);
                    Result = _currentOperand;
                    break;

                case ",":
                    _lastOperation = ",";
                    Calculate();
                    break;

                case "+/-":
                    if (_currentOperand != string.Empty)
                    {
                        if (_currentOperand[0] == '-')
                        {
                            _currentOperand = _currentOperand.Substring(1, _currentOperand.Length - 1);
                        }
                        else
                        {
                            _currentOperand = "-" + _currentOperand;
                        }

                        Result = _currentOperand;
                    }
                    break;

                case "sin":
                    _lastOperation = "sin";
                    Calculate();
                    break;

                case "cos":
                    _lastOperation = "cos";
                    Calculate();
                    break;

                case "tan":
                    _lastOperation = "tan";
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
                    break;

                case "-":
                    resultOfOperation = Convert.ToDouble(_exOperand) - Convert.ToDouble(_currentOperand);
                    _currentOperand = Convert.ToString(resultOfOperation);
                    _exOperand = string.Empty;
                    Result = _currentOperand;                   
                    break;

                case "*":
                    resultOfOperation = Convert.ToDouble(_exOperand) * Convert.ToDouble(_currentOperand);
                    _currentOperand = Convert.ToString(resultOfOperation);
                    _exOperand = string.Empty;
                    Result = _currentOperand;                    
                    break;

                case "/":
                    if (_currentOperand != "0")
                    {
                        resultOfOperation = Convert.ToDouble(_exOperand) / Convert.ToDouble(_currentOperand);
                        _currentOperand = Convert.ToString(resultOfOperation);
                        _exOperand = string.Empty;
                        Result = _currentOperand;                        
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
                    _currentOperand = Convert.ToString(resultOfOperation);                    
                    Result = _currentOperand;
                    break;

                case "!n":
                    int CeiledCurrentOperand = Math.Abs(Convert.ToInt32(Convert.ToDouble(_currentOperand)));
                    int result = 1;

                    for (int i = 1; i <= CeiledCurrentOperand; i++)
                    {
                        result *= i;
                    }
                    _currentOperand = Convert.ToString(result);
                    Result = _currentOperand;
                    break;

                case "ln":
                    resultOfOperation = Math.Log(Convert.ToDouble(_currentOperand));                    
                    _currentOperand = Convert.ToString(resultOfOperation);                    
                    Result = _currentOperand;
                    break;                                                                    
                

                case "sin":
                    resultOfOperation = Math.Sin(Convert.ToDouble(_currentOperand));
                    _currentOperand = Convert.ToString(resultOfOperation);
                    Result = _currentOperand;
                    break;

                case "cos":
                    resultOfOperation = Math.Cos(Convert.ToDouble(_currentOperand));
                    _currentOperand = Convert.ToString(resultOfOperation);
                    Result = _currentOperand;
                    break;

                case "tan":
                    resultOfOperation = Math.Tan(Convert.ToDouble(_currentOperand));
                    _currentOperand = Convert.ToString(resultOfOperation);
                    Result = _currentOperand;
                    break;

                case ",":
                    if (!_currentOperand.Contains(","))
                    {
                        _isOperationPending = false;
                        _currentOperand += ",";
                        Result = _currentOperand;
                    }
                    break;

            }
        }
    }
}
