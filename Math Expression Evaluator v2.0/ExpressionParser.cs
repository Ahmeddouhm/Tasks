using System;
using System.Collections.Generic;
using System.Text;

namespace Math_Expression_Evaluator_v2._0
{
    internal class ExpressionParser
    {
        private const string MathSymbols = "+*/^%";
        public static MathExpression Parse(string input)
        {
            MathExpression expression = new MathExpression();
            bool leftSideInitialized = false;
            string token = "";

            for (int i = 0; i < input.Length; i++)
            {
                var currChar = input[i];

                if (char.IsDigit(currChar))
                {
                        token += currChar;
                        if (i == input.Length - 1 && leftSideInitialized)
                        {
                            expression.RightSideOp = double.Parse(token);
                            break;
                        }
                }
                else if (char.IsLetter(currChar)) 
                {
                    token += currChar;
                    leftSideInitialized = true;
                }
                else if (currChar == ' ') 
                {
                    if (!leftSideInitialized)
                    {
                        expression.LeftSideOp = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                    else if (expression.Operation ==  MathOperation.None)
                    {
                        expression.Operation = MathOperationParser(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                }
                else if (currChar == '-' && i > 0) 
                {
                    if (expression.Operation == MathOperation.None)
                    {
                        expression.Operation = MathOperation.Subtraction;
                        expression.LeftSideOp = double.Parse(token);
                        leftSideInitialized = true;
                        token = "";
                    }
                    else
                    {
                        token += currChar;
                    }
                }
                else if (MathSymbols.Contains(currChar)) 
                {
                    if (!leftSideInitialized)
                    {
                        expression.LeftSideOp = double.Parse(token);
                        leftSideInitialized = true;
                    }
                    expression.Operation = MathOperationParser(currChar.ToString());
                    token = "";
                }
                else 
                {
                    token += currChar;
                }
            }
            return expression;
        }

        private static MathOperation MathOperationParser(string operation) 
        {
            switch (operation.ToLower())
            {
                case "+":
                    return MathOperation.Addition;
                case "-":
                    return MathOperation.Subtraction;
                case "*":
                    return MathOperation.Multiplication;
                case "/":
                    return MathOperation.Division;
                case "pow":
                case "^":
                    return MathOperation.Power;
                case "%":
                case "mod":
                    return MathOperation.Modulus;
                case "sin":
                    return MathOperation.Sin;
                case "cos":
                    return MathOperation.Cos;
                case "tan":
                    return MathOperation.Tan;
                default:
                    return MathOperation.None;
            }
        }
    }
}
