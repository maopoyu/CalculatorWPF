using System.Windows;
using System.Windows.Input;
using CalculatorWPF.ViewModels;

namespace CalculatorWPF.Views
{
    /// <summary>
    /// Interaction logic for CalculatorView.xaml
    /// </summary>
    public partial class CalculatorView : Window
    {
        public CalculatorView()
        {
            InitializeComponent();
            DataContext = new CalculatorViewModel();
        }

        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (DataContext is not CalculatorViewModel viewModel) return;
            
            switch (e.Text)
            {
                case "+":
                    viewModel.OperatorCommand.Execute("+");
                    e.Handled = true;
                    break;
                case "-":
                    viewModel.OperatorCommand.Execute("-");
                    e.Handled = true;
                    break;
                case "*":
                case "×":
                    viewModel.OperatorCommand.Execute("×");
                    e.Handled = true;
                    break;
                case "/":
                case "÷":
                    viewModel.OperatorCommand.Execute("÷");
                    e.Handled = true;
                    break;
            }
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (DataContext is not CalculatorViewModel viewModel) return;

            bool handled = false;

            switch (e.Key)
            {
                case Key.D0:
                case Key.NumPad0:
                    viewModel.AddInputCommand.Execute("0");
                    handled = true;
                    break;
                case Key.D1:
                case Key.NumPad1:
                    viewModel.AddInputCommand.Execute("1");
                    handled = true;
                    break;
                case Key.D2:
                case Key.NumPad2:
                    viewModel.AddInputCommand.Execute("2");
                    handled = true;
                    break;
                case Key.D3:
                case Key.NumPad3:
                    viewModel.AddInputCommand.Execute("3");
                    handled = true;
                    break;
                case Key.D4:
                case Key.NumPad4:
                    viewModel.AddInputCommand.Execute("4");
                    handled = true;
                    break;
                case Key.D5:
                case Key.NumPad5:
                    viewModel.AddInputCommand.Execute("5");
                    handled = true;
                    break;
                case Key.D6:
                case Key.NumPad6:
                    viewModel.AddInputCommand.Execute("6");
                    handled = true;
                    break;
                case Key.D7:
                case Key.NumPad7:
                    viewModel.AddInputCommand.Execute("7");
                    handled = true;
                    break;
                case Key.D8:
                case Key.NumPad8:
                    viewModel.AddInputCommand.Execute("8");
                    handled = true;
                    break;
                case Key.D9:
                case Key.NumPad9:
                    viewModel.AddInputCommand.Execute("9");
                    handled = true;
                    break;
                case Key.OemPeriod:
                case Key.Decimal:
                    viewModel.AddInputCommand.Execute(".");
                    handled = true;
                    break;
                case Key.Add: // Numpad +
                    viewModel.OperatorCommand.Execute("+");
                    handled = true;
                    break;
                case Key.Subtract: // Numpad -
                    viewModel.OperatorCommand.Execute("-");
                    handled = true;
                    break;
                case Key.Multiply: // Numpad *
                    viewModel.OperatorCommand.Execute("×");
                    handled = true;
                    break;
                case Key.Divide: // Numpad /
                    viewModel.OperatorCommand.Execute("÷");
                    handled = true;
                    break;
                case Key.Enter:
                    viewModel.EqualsCommand.Execute(null);
                    handled = true;
                    break;
                case Key.Escape:
                    viewModel.ClearAllCommand.Execute(null);
                    handled = true;
                    break;
                case Key.Delete:
                    viewModel.ClearEntryCommand.Execute(null);
                    handled = true;
                    break;
                case Key.Back:
                    viewModel.BackspaceCommand.Execute(null);
                    handled = true;
                    break;
            }

            if (handled)
            {
                e.Handled = true;
            }
        }
    }
}