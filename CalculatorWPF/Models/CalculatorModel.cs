namespace CalculatorWPF.Models
{
    public static class CalculatorModel
    {
        public static decimal Calculate(decimal operand1, decimal operand2, string @operator)
        {
            switch (@operator)
            {
                case "+":
                    return operand1 + operand2;
                case "-":
                    return operand1 - operand2;
                case "×":
                    return operand1 * operand2;
                case "÷":
                    if (operand2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    return operand1 / operand2;
                default:
                    throw new InvalidOperationException("Invalid operator");
            }
        }
    }
} 