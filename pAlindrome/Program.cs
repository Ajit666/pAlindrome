using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace pAlindrome
{
    class Program
    {
        const char leftBracket = '(';
        const char rightBracket = ')';
        const char leftCurlyBracket = '{';
        const char rightCurlyBracket = '}';
        const char leftBigBracket = '[';
        const char rightBigBracket = ']';


        private static char[] charArry = new char[] { '(', ')', '[', ']', '{', '}' };


        static void Main(string[] args)
        {
            Console.WriteLine("Enter string");
            string stringToCheck = Console.ReadLine();
            
            if (!isValidString(stringToCheck, out string lastEror))
            {
                Console.WriteLine($"{lastEror}");
                System.Environment.Exit(0);
            }
            int tempValue = 0;

            var strArray = new string(stringToCheck.ToArray());
            Console.WriteLine(strArray.Length);
            for (var i = 0; i < (strArray.Length / 2); i++)
            {
                for (var j = strArray.Length - 1 - i; j >= 0; j--)
                {
                    if (strArray[i] == '(')
                    {
                        tempValue = (int)')';
                        if ((int)strArray[j] == tempValue)
                        {
                            tempValue = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Entered combination of parenthesis is not Balance!!");
                            System.Environment.Exit(0);
                        }
                    }

                    if (strArray[i] == '{')
                    {
                        tempValue = (int)'}';
                        if ((int)strArray[j] == tempValue)
                        {
                            tempValue = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Entered combination of parenthesis is not Balance!!");
                            System.Environment.Exit(0);
                        }
                    }

                    if (strArray[i] == '[')
                    {
                        tempValue = (int)']';
                        if ((int)strArray[j] == tempValue)
                        {
                            tempValue = 0;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Entered combination of parenthesis is not Balanced!!");
                            System.Environment.Exit(0);
                        }
                    }
                }

            }
            Console.WriteLine("Entered combination of parenthesis is Balanced!!");
        }

        public static bool isValidString(string stringToCheck, out string errorResult)
        {
            try
            {
                Regex rgx = new Regex(@"\w+");
                if (rgx.IsMatch(stringToCheck))
                {
                    errorResult = @"Its Not a valid string";
                    return false;
                }

                if ((stringToCheck.IndexOf(leftBracket) == -1) || (stringToCheck.IndexOf(rightBracket) == -1) || (stringToCheck.IndexOf(leftCurlyBracket) == -1) || (stringToCheck.IndexOf(rightCurlyBracket) == -1) || (stringToCheck.IndexOf(leftBigBracket) == -1) || (stringToCheck.IndexOf(rightBigBracket) == -1))
                {
                    errorResult = @"One of the three Parenthesis is missing";
                    return false;
                }

                if (stringToCheck.Length % 2 != 0)
                {
                    errorResult = @"Its Not a Balanced string";
                    return false;
                }

                errorResult = @"Its Not a valid string";
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}