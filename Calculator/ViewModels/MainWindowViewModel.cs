using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reactive;

namespace Calculator.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _result = "0";
        private string _currentOperand = string.Empty;
        private string _exOperand = string.Empty;
        private string _lastOperation = string.Empty;
        private string _lastOperand = string.Empty;
        private bool _isOperationPending = false;


        public ReactiveCommand<string, Unit> NumberButtonCommand { get; }
        public MainWindowViewModel()
        {
            NumberButtonCommand = ReactiveCommand.Create<string>(NumberButtonAction);
        }

        public string Result
        {
            get { return _result; }
            set => this.RaiseAndSetIfChanged(ref _result, value);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}