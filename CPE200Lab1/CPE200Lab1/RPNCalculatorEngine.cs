﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPE200Lab1
{
    public class RPNCalculatorEngine : CalculatorEngine
    {
        public new string Process(string str)
        {
            if(str == "0")
            {
                return "0";
            }

            if (str == null || str == "")
            {
                return "E";
            }
                
            Stack<string> rpnStack = new Stack<string>();
            List<String> parts = str.Split(' ').ToList<string>();

            string result;
            string firstOperand, secondOperand;

            foreach (string token in parts)
            {
                if (isOperator(token))
                {

                    //FIXME, what if there is only one left in stack?
                    if (rpnStack.Count < 2)
                    {
                        return "E";
                    }
                    secondOperand = rpnStack.Pop();
                    firstOperand = rpnStack.Pop();
                    result = calculate(token, firstOperand, secondOperand, 4);

                    if (result == "E")
                    {
                        return result;
                    }
                    rpnStack.Push(result);
                }
                else if (isNumber(token))
                {
                    int i;
                    for (i = 0; i < token.Length; i++)
                    {
                        if (token[i] == '+')
                            return "E";
                    }
                    rpnStack.Push(token);
                }
                else
                {
                    int i;
                    for (i = 0; i < token.Length; i++)
                    {
                        if (token[i] == '+')
                        {
                            if (token.Length > 1)
                            {
                                return "E";
                            }
                        }
                    }
                }
            }
            //FIXME, what if there is more than one, or zero, items in the stack?
            if(rpnStack.Count != 0)
            {
                result = rpnStack.Pop();
            }
            else
            {
                result = "E";
            }
            return result;
        }
    }
}
