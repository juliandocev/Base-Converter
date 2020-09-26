using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Base_Converter
{
    class Program
    {
        public static Dictionary<string, int> dict;
        static void Main(string[] args)
        {
            int from;
            int to;
            string number;
            dict = new Dictionary<string, int>();
            dict.Add("A", 10);
            dict.Add("B", 11);
            dict.Add("C", 12);
            dict.Add("D", 13);
            dict.Add("E", 14);
            dict.Add("F", 15);
            // DecimalToAll(10, 16, 95);
            //AllToDecimal(16,10,"5F");
            Console.WriteLine("This is a Base to Base converter. To define the base use a number( Exp: 10 for decimal, 2 for binary etc...");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("From which base you whant to convert?");
            from  = Convert.ToInt32( Console.ReadLine());

            Console.WriteLine("To which base?");
            to = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What's the number?");
            number = Console.ReadLine();

            Console.WriteLine("Your answere is: ");
            Console.WriteLine(AlltoAllConvertion(from, to, number)); 
        }
        public static string  AlltoAllConvertion(int from, int to, string number)
        {
            string result = "";
            if(from != 10)
            {
                result = AllToDecimal(from, to, number);
                if(to != 10)
                {
                    return DecimalToAll(10, to, result);
                }
                return result;
            }
            return DecimalToAll(10, to, number);
        }
        public static string DecimalToAll(int from, int to, string num)
        {
            int number = Convert.ToInt32(num);
            List<string> result= new List<string>();
            string resultReversed = "";
            while (number > 0)
            {
                int pop= 0;
                pop = number % to;
                // if it is a 16 we must add a letter fpr bigger numbers
                if(to == 16 && pop>=10)
                {
                    string pop16 = dict.FirstOrDefault(x => x.Value == pop).Key.ToString();
                    result.Add(pop16.ToString());
                }// no 16, or no need of a letter
                else
                {
                    result.Add(pop.ToString());
                }

                number = number / to;
            }
            // reverse the string
            for (int i = result.Count-1; i  >=0; i--)
            {
                resultReversed += result[i];
            }
            return resultReversed;
        }
        public static string AllToDecimal(int from, int to, string number)
        {
            double result = 0;
            int pow = 0;

            for (int i = number.Length-1; i >= 0; i--)
            {
                // from any base except 16
                if(from != 16)
                {
                    string num = number[i].ToString();
                    result += Int64.Parse(num) * Math.Pow(from, pow);
                }
                else// if it is 16 base
                {
                    int numInt = 0;
                    string num = number[i].ToString();
                    // convert the 16 bqse letter to number
                    if ((char.IsLetter(num.ToCharArray()[0])))
                    {
                        numInt = dict.FirstOrDefault(x => x.Key == num).Value;
                        result += numInt * Math.Pow(from, pow);
                    } 
                    else
                    {
                        result += Int64.Parse(num) * Math.Pow(from, pow);
                    }
                }

                pow++;
            }

            return result.ToString();
        }
    }
}
