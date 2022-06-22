using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Calculator
    {
        List<string> data;
        public Calculator(List<string> _data)
        {
            data = _data;
        }

        public int Count()
        {
            Queue<string> queue = new Queue<string>();
            Stack<string> operators = new Stack<string>();
            Stack<int> nums = new Stack<int>();

            foreach(string s in data)
            {
                int n;
                if (int.TryParse(s, out n))
                {
                    queue.Enqueue(s);
                }
                else
                {
                    var o = new Operators();

                    if (operators.Count < 1)
                    {
                        operators.Push(s);
                        continue;
                    }

                    if(s == ")")
                    {
                        while(operators.Peek() != "(")
                        {
                            queue.Enqueue(operators.Pop());
                        }
                        operators.Pop();
                        continue;
                    }

                    int last_o_in_stack_priority = o.GetPriority(operators.Peek());
                    int o_priority = o.GetPriority(s);

                    if(last_o_in_stack_priority > o_priority)
                    {
                        queue.Enqueue(operators.Pop());
                        operators.Push(s);

                    } else
                    {
                        operators.Push(s);
                    }
                }
            }



            while (operators.Count() > 0)
            {
                queue.Enqueue(operators.Pop());
            }

            while (queue.Count() > 0)
            {
                int num;
                if(int.TryParse(queue.Peek(), out num))
                {
                    queue.Dequeue();
                    nums.Push(num);
                } else
                {
                    int result = 0;

                    string o = queue.Dequeue();
                    int operand_2 = nums.Pop();
                    int operand_1 = nums.Pop();

                    if(o == "-")
                    {
                        result = operand_1 - operand_2;
                    }

                    if (o == "+")
                    {
                        result = operand_1 + operand_2;
                    }

                    if (o == "*")
                    {
                        result = operand_1 * operand_2;
                    }

                    if (o == "/")
                    {
                        result = operand_1 / operand_2;
                    }

                    if (o == "^")
                    {
                        result = Convert.ToInt32(Math.Pow(operand_1, operand_2));
                    }

                    nums.Push(result);
                }
            }

            return nums.Pop();
        }

    }
}