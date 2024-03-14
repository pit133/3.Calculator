using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;
using System;
using System.ComponentModel;
using System.Reactive;

namespace Calculator.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _result = "0";
        private string _currentOperand = string.Empty;
        private string _lastOperation = string.Empty;
        private bool _isOperationPending = false;

        private IImmutableSolidColorBrush _buttonColor = Brushes.Blue; 

        public IImmutableSolidColorBrush ButtonColor
        {
            get => _buttonColor;
            set => this.RaiseAndSetIfChanged(ref _buttonColor, value);
        }

        public ReactiveCommand<string, Unit> NumberButtonCommand { get; }
        public ReactiveCommand<Unit, Unit> ChangeButtonColorCommand { get; }

        public MainWindowViewModel()
        {
            NumberButtonCommand = ReactiveCommand.Create<string>(NumberButtonAction);
            ChangeButtonColorCommand = ReactiveCommand.Create(ChangeButtonColor);
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

        public void ChangeButtonColor()
        {
            // В этом методе измените цвет кнопки
            ButtonColor = Brushes.Red; // Например, измените на красный
        }

        public void Add()
        {
            ChangeButtonColor();
        }

    }
}