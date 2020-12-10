using Blazor.Wpf.Components;
using Microsoft.AspNetCore.Components.Web;
using System;

namespace Blazor.Wfp.Calculator.Pages
{
    public partial class Index
    {
        static string defaultString = "0.0";
        string numberOneBuffer;
        string numberTwoBuffer;
        Calc c;
        IText textBox1 { get; set; }
        IItems listBox1 { get; set; }

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
                textBox1.Text = defaultString;
                c = new Calc();

                numberOneBuffer = "";
                numberTwoBuffer = "";
            }
        }

        private void one_Click(MouseEventArgs e)
        {
            Console.WriteLine("My debug output.");
            numberOneBuffer += "1";
            textBox1.Text = numberOneBuffer;
        }

        private void two_Click(MouseEventArgs e)
        {
            numberOneBuffer += "2";
            textBox1.Text = numberOneBuffer;
        }

        private void three_Click(MouseEventArgs e)
        {
            numberOneBuffer += "3";
            textBox1.Text = numberOneBuffer;
        }

        private void four_Click(MouseEventArgs e)
        {
            numberOneBuffer += "4";
            textBox1.Text = numberOneBuffer;
        }

        private void five_Click(MouseEventArgs e)
        {
            numberOneBuffer += "5";
            textBox1.Text = numberOneBuffer;
        }

        private void six_Click(MouseEventArgs e)
        {
            numberOneBuffer += "6";
            textBox1.Text = numberOneBuffer;
        }

        private void seven_Click(MouseEventArgs e)
        {
            numberOneBuffer += "7";
            textBox1.Text = numberOneBuffer;
        }

        private void eight_Click(MouseEventArgs e)
        {
            numberOneBuffer += "8";
            textBox1.Text = numberOneBuffer;
        }

        private void nine_Click(MouseEventArgs e)
        {
            numberOneBuffer += "9";
            textBox1.Text = numberOneBuffer;
        }

        private void zero_Click(MouseEventArgs e)
        {
            numberOneBuffer += "0";
            textBox1.Text = numberOneBuffer;
        }

        private void decipoint_Click(MouseEventArgs e)
        {
            numberOneBuffer += ".";
        }

        private void enter_Click(MouseEventArgs e)
        {
            string answer = "";
            if (c.isFirstOperation() || ((numberOneBuffer.Length > 0) && (numberTwoBuffer.Length > 0)))
            {
                answer = c.operate(Convert.ToDouble(numberTwoBuffer), Convert.ToDouble(numberOneBuffer));
            }
            else
            {
                answer = c.operate(Convert.ToDouble(numberTwoBuffer));
            }

            textBox1.Text = answer;
            updateList(answer);
            numberOneBuffer = "";
            numberTwoBuffer = "";
        }

        private void updateList(string answer)
        {
            string s = numberTwoBuffer;

            Calc.Operators op = c.getOperation();
            switch (op)
            {
                case Calc.Operators.Addition:
                    s += " + ";
                    break;
                case Calc.Operators.Subtraction:
                    s += " - ";
                    break;
                case Calc.Operators.Multiplication:
                    s += " x ";
                    break;
                case Calc.Operators.Division:
                    s += " % ";
                    break;
            }

            s += numberOneBuffer;
            s += " = ";
            s += answer;
            listBox1.AddItem(s);
        }

        private void sign_Click(MouseEventArgs e)
        {
            if (numberOneBuffer.Length > 0)
            {
                if (numberOneBuffer[0] == '-')
                {
                    numberOneBuffer = numberOneBuffer.Substring(1, numberOneBuffer.Length - 1);
                }
                else
                {
                    numberOneBuffer = "-" + numberOneBuffer;
                }
            }
            else
            {
                numberOneBuffer = "-" + numberOneBuffer;
            }
            textBox1.Text = Convert.ToString(numberOneBuffer);
        }

        private void clearentry_Click(MouseEventArgs e)
        {
            numberOneBuffer = "";
            textBox1.Text = defaultString;
        }

        private void clear_Click(MouseEventArgs e)
        {
            numberOneBuffer = "";
            c.reset();
            textBox1.Text = defaultString;
        }

        private void add_Click(MouseEventArgs e)
        {
            if ((numberOneBuffer.Length > 0) && (numberTwoBuffer.Length > 0))
            {
                string answer = c.operate(Convert.ToDouble(numberTwoBuffer), Convert.ToDouble(numberOneBuffer));
                textBox1.Text = answer;
                c.setOperation(Calc.Operators.Addition);
            }
            else
            {
                c.setOperation(Calc.Operators.Addition);
                numberTwoBuffer = numberOneBuffer;
                numberOneBuffer = string.Empty;
            }

        }

        private void minus_Click(MouseEventArgs e)
        {
            if ((numberOneBuffer.Length > 0) && (numberTwoBuffer.Length > 0))
            {
                textBox1.Text = c.operate(Convert.ToDouble(numberTwoBuffer), Convert.ToDouble(numberOneBuffer));
            }
            c.setOperation(Calc.Operators.Subtraction);
            numberTwoBuffer = numberOneBuffer;
            numberOneBuffer = string.Empty;
        }

        private void multiple_Click(MouseEventArgs e)
        {
            if ((numberOneBuffer.Length > 0) && (numberTwoBuffer.Length > 0))
            {
                textBox1.Text = c.operate(Convert.ToDouble(numberTwoBuffer), Convert.ToDouble(numberOneBuffer));
            }
            c.setOperation(Calc.Operators.Multiplication);
            numberTwoBuffer = numberOneBuffer;
            numberOneBuffer = string.Empty;
        }

        private void divide_Click(MouseEventArgs e)
        {
            if ((numberOneBuffer.Length > 0) && (numberTwoBuffer.Length > 0))
            {
                textBox1.Text = c.operate(Convert.ToDouble(numberTwoBuffer), Convert.ToDouble(numberOneBuffer));
            }
            c.setOperation(Calc.Operators.Division);
            numberTwoBuffer = numberOneBuffer;
            numberOneBuffer = string.Empty;
        }

        private string checkDecimal(string s)
        {
            if (s[s.Length - 1] == '.')
            {
                s += "0";
            }
            return s;
        }
    }
}

