using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public string Operator
        {
            get { return this._operator; }
            set
            {
                switch (value)
                {
                    case "+":
                        break;
                    case "-":
                        break;
                    case "×":
                        break;
                    case "/":
                        break;
                    default:
                        return;
                }
                this._operator = value;
            }
        }

        public string Equal(string value)
        {
            var decimalValue1 = ToDecimal(FirstValue);
            var decimalValue2 = ToDecimal(value);
            FirstValue = OperatorCalculate(decimalValue1, decimalValue2).ToString();
            return FirstValue;
        }

        public string FirstValue { get; set; } = "0";

        private string _operator = string.Empty;

        private decimal ToDecimal(string value)
        {
            decimal result = default(decimal);
            Decimal.TryParse(value,out result);
            return result;
        }

        private decimal OperatorCalculate(decimal value1,decimal value2)
        {
            switch (Operator)
            {
                case "+":
                    return value1 + value2;
                case "-":
                    return value1 - value2;
                case "×":
                    return value1 * value2;
                case "/":
                    return value1 / value2;
                default:
                    return default(decimal);
            }
        }
    }
}