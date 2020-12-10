using System;

namespace Blazor.Wfp.Calculator.Pages
{
    class Calc
    {
        public enum Operators
        {
            None,
            Addition,
            Subtraction,
            Multiplication,
            Division
        };

        private Operators op;
        private bool firstOperation;
        private double answer;

        public Calc()
        {
            answer = 0.0;
            op = Operators.None;
            firstOperation = true;
        }

        public bool isFirstOperation()
        {
            return firstOperation;
        }

        public string operate(double a, double b)
        {
            firstOperation = false;

            switch (op)
            {
                case Operators.Addition:
                    answer = addition(a, b);
                    break;
                case Operators.Subtraction:
                    answer = subtraction(a, b);
                    break;
                case Operators.Multiplication:
                    answer = multiplication(a, b);
                    break;
                case Operators.Division:
                    if (b == 0.0)
                    {
                        return "NaN";
                    }
                    else
                    {
                        answer = division(a, b);
                    }
                    break;
            };

            return Convert.ToString(answer);
        }

        public string operate(double a)
        {
            return operate(answer, a);
        }

        public void setOperation(Operators op)
        {
            this.op = op;
        }

        public void reset()
        {
            firstOperation = true;
            op = Operators.None;
        }

        // Static operators
        static public double addition(double a, double b)
        {
            return a + b;
        }

        static public double subtraction(double a, double b)
        {
            return a - b;
        }

        static public double multiplication(double a, double b)
        {
            return a * b;
        }

        static public double division(double a, double b)
        {
            return a / b;
        }


        public Operators getOperation()
        {
            return op;
        }
    }
}
