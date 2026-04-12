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

            for (int i = 0; i < input.Length; i++)
            {
                var currChar = input[i];
                if (char.IsDigit(currChar))
                {

                }
                else if () { }
                else if () { }
                else if () { }
                else if () { }
                else if () { }
                else 
                {
                
                }
            }
        }
    }
}
