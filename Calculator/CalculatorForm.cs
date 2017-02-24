using System;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void NumberClick(object sender, EventArgs e)
        {
            var number = (sender as Button).Text;

            if(_clickEqual)
            {
                lblPrevious.Text = string.Empty;
                tbxResult.Text = number;
                _clickEqual = false;
                return;
            }

            if(IsNumber(tbxResult.Text))
            {   // 是數字
                tbxResult.Text += number;
            }
            else
            {  // 是運算元
                lblPrevious.Text += tbxResult.Text;
                tbxResult.Text = number;
            }
            return;            
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (tbxResult.Text.Contains('.')) return;
            if (tbxResult.Text.Length == 0) return;
            tbxResult.Text += ".";
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            tbxResult.Text = string.Empty;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            lblPrevious.Text = string.Empty;
            tbxResult.Text = string.Empty;
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (this._calculator.Operator == string.Empty) return;
            if (tbxResult.Text == string.Empty) return;

            _clickEqual = true;

            lblPrevious.Text += tbxResult.Text;
            this._calculator.Equal(tbxResult.Text);
            tbxResult.Text = this._calculator.FirstValue;
        }

        private void OperatorClick(object sender, EventArgs e)
        {
            if (tbxResult.Text == string.Empty) return;
            if (IsNumber(tbxResult.Text) == false) return;

                if (_clickEqual)
            {
                lblPrevious.Text = tbxResult.Text;
                _clickEqual = false;
            }
            else
            {
                lblPrevious.Text += tbxResult.Text;
            }

            var oper = (sender as Button).Tag.ToString();
            this._calculator.Operator = oper;

            this._calculator.FirstValue = tbxResult.Text;
            tbxResult.Text = oper;
        }

        private bool _clickEqual = false;
        private Calculator _calculator = new Calculator();

        private bool IsNumber(string value)
        {
            decimal tmp;
            if (decimal.TryParse(tbxResult.Text, out tmp))
            {   
                return true;
            }
            return false;
        }
    }
}
