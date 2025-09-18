using CalculatorWPF.Models;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CalculatorWPF.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        private string _displayText = "0";
        private decimal? _operand1;
        private string? _operator;
        private bool _isNewEntry = true;
        private decimal _memoryValue = 0;
        private bool _isMrcPressedOnce = false;
        private decimal? _lastOperand;
        private bool _calculationJustFinished = false;

        public string DisplayText
        {
            get => _displayText;
            set
            {
                if (_displayText != value)
                {
                    _displayText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AddInputCommand { get; }
        public ICommand ClearAllCommand { get; }
        public ICommand ClearEntryCommand { get; }
        public ICommand OperatorCommand { get; }
        public ICommand EqualsCommand { get; }
        public ICommand MemoryAddCommand { get; }
        public ICommand MemorySubtractCommand { get; }
        public ICommand MemoryRecallClearCommand { get; }
        public ICommand BackspaceCommand { get; }


        public CalculatorViewModel()
        {
            AddInputCommand = new RelayCommand(AddInput);
            ClearAllCommand = new RelayCommand(ClearAll);
            ClearEntryCommand = new RelayCommand(ClearEntry);
            OperatorCommand = new RelayCommand(ExecuteOperation);
            EqualsCommand = new RelayCommand(CalculateResult);
            MemoryAddCommand = new RelayCommand(MemoryAdd);
            MemorySubtractCommand = new RelayCommand(MemorySubtract);
            MemoryRecallClearCommand = new RelayCommand(MemoryRecallClear);
            BackspaceCommand = new RelayCommand(Backspace);
        }

        private void AddInput(object? parameter)
        {
            var input = parameter as string;
            if (input == null) return;

            if (_isNewEntry || _calculationJustFinished)
            {
                if (_calculationJustFinished)
                {
                    _operand1 = null;
                    _lastOperand = null;
                }
                
                DisplayText = "0";
                _isNewEntry = false;
                _calculationJustFinished = false;
            }

            _isMrcPressedOnce = false;

            if (DisplayText == "0" && input != ".")
            {
                if (input == "00")
                {
                    return; 
                }
                DisplayText = input;
            }
            else
            {
                if (input == "." && DisplayText.Contains(".")) return;
                if (DisplayText.Length >= 20) return;
                DisplayText += input;
            }
        }

        private void ClearAll(object? parameter)
        {
            DisplayText = "0";
            _operand1 = null;
            _operator = null;
            _lastOperand = null;
            _isNewEntry = true;
            _isMrcPressedOnce = false;
            _calculationJustFinished = false;
        }

        private void ClearEntry(object? parameter)
        {
            DisplayText = "0";
            _isNewEntry = true;
            _isMrcPressedOnce = false;
            _calculationJustFinished = false;
        }

        private void ExecuteOperation(object? parameter)
        {
            var op = parameter as string;
            if (op == null) return;

            if (_operand1.HasValue && !_isNewEntry)
            {
                CalculateResult(null);
            }
            
            if (decimal.TryParse(DisplayText, out decimal number))
            {
                _operand1 = number;
            }

            _operator = op;
            _isNewEntry = true;
            _isMrcPressedOnce = false;
            _lastOperand = null;
            _calculationJustFinished = false;
        }

        private void CalculateResult(object? parameter)
        {
            if (!_operand1.HasValue || _operator == null)
            {
                return;
            }

            decimal operand2;
            if (_isNewEntry)
            {
                if (!_lastOperand.HasValue) return;
                operand2 = _lastOperand.Value;
            }
            else
            {
                if (!decimal.TryParse(DisplayText, out var currentDisplayValue)) return;
                operand2 = currentDisplayValue;
                _lastOperand = operand2;
            }

            try
            {
                decimal result = CalculatorModel.Calculate(_operand1.Value, operand2, _operator);
                _operand1 = result;
                DisplayText = result.ToString();
            }
            catch (DivideByZeroException)
            {
                DisplayText = "Error";
                _operand1 = null;
                _operator = null;
                _lastOperand = null;
            }
            catch (InvalidOperationException)
            {
                DisplayText = "Error";
                _operand1 = null;
                _operator = null;
                _lastOperand = null;
            }

            _isNewEntry = true;
            _isMrcPressedOnce = false;
            if (DisplayText != "Error")
            {
                _calculationJustFinished = true;
            }
        }

        private void MemoryAdd(object? parameter)
        {
            if (_operand1.HasValue && _operator != null && !_isNewEntry)
            {
                CalculateResult(null);
            }

            if (decimal.TryParse(DisplayText, out decimal number))
            {
                _memoryValue += number;
            }
            _isNewEntry = true;
            _isMrcPressedOnce = false;
        }

        private void MemorySubtract(object? parameter)
        {
            if (_operand1.HasValue && _operator != null && !_isNewEntry)
            {
                CalculateResult(null);
            }

            if (decimal.TryParse(DisplayText, out decimal number))
            {
                _memoryValue -= number;
            }
            _isNewEntry = true;
            _isMrcPressedOnce = false;
        }

        private void MemoryRecallClear(object? parameter)
        {
            if (_isMrcPressedOnce)
            {
                _memoryValue = 0;
                _isMrcPressedOnce = false;
            }
            else
            {
                DisplayText = _memoryValue.ToString();
                _isMrcPressedOnce = true;
                _isNewEntry = true;
            }
            _calculationJustFinished = false;
        }

        private void Backspace(object? parameter)
        {
            if (DisplayText.Length > 1)
            {
                DisplayText = DisplayText.Substring(0, DisplayText.Length - 1);
            }
            else
            {
                DisplayText = "0";
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
} 