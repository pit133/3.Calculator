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
        public void CountLg()
        {
            double lgOfnumber = Convert.ToDouble(_currentOperand);
            lgOfnumber = Math.Log10(lgOfnumber);
            _isOperationPending = true;
            _currentOperand = Convert.ToString(lgOfnumber);
            Result = Convert.ToString(lgOfnumber);
        }

        public void CountLn()
        {
            double lnOfnumber = Convert.ToDouble(_currentOperand);
            lnOfnumber = Math.Log(lnOfnumber);
            _isOperationPending = true;
            _currentOperand = Convert.ToString(lnOfnumber);
            Result = Convert.ToString(lnOfnumber);
        }

        public void Floor()
        {
            double floorOfnumber = Convert.ToDouble(_currentOperand);
            floorOfnumber = Math.Floor(floorOfnumber);
            _isOperationPending = true;
            _currentOperand = Convert.ToString(floorOfnumber);
            Result = Convert.ToString(floorOfnumber);
        }

        public void Ceil()
        {
            double CeilOfnumber = Convert.ToDouble(_currentOperand);
            CeilOfnumber = Math.Ceiling(CeilOfnumber);
            _isOperationPending = true;
            _currentOperand = Convert.ToString(CeilOfnumber);
            Result = Convert.ToString(CeilOfnumber);
        }

        public void AddPoint()
        {
            if (!_currentOperand.Contains(","))
            {
                _isOperationPending = false;
                _currentOperand += ",";
                Result = _currentOperand;
            }
        }

        public void ChangeSign()
        {
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
        }

    }
}
