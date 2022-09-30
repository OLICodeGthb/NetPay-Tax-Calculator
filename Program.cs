using System;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("================================================");
                Console.WriteLine("--- TAX INCOME CALCULATOR ---");
                Console.WriteLine("================================================");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(" ====== Please enter annual salary here: ");
                double salary = double.Parse(Console.ReadLine());
                //Calculate Gross pay per month
                //Divide annual salary by 12 to get monthly salary
                double grossPay = (salary / 12);
                //Calculate deductions
                //Calculate taxable income(monthly salary minus £1, 047.5)
                double deductionTax = grossPay - 1047.5;
                //Calculate income tax(20 % of taxable income)
                double incomeTax = deductionTax / 20 * 100;
                //Calculate national insurance:
                //if gross pay is over £967 - national insurance is ((Gross pay – 967) *2 %) + ((967 - 184) * 12 %)
                double nationalInsurance;
                if (grossPay > 967)
                {
                    nationalInsurance = (double)(((grossPay - 967) * 2 / 100) + ((967 - 184 * 12 / 100)));

                }
                //else -national insurance is ((Gross pay -184) *12 %)
                else
                {
                    nationalInsurance = ((double)((grossPay - 184) / 12 * 100));
                }
                double natIncomeValue = nationalInsurance + incomeTax;
                //Calculate NET pay
                //Deduct deductions from Gross pay
                double netPay = (grossPay - natIncomeValue);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("================================================");
                Console.WriteLine($"The netpay that has been calculated is {netPay}");
                Console.WriteLine("================================================");
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("================================================");
                Console.WriteLine("Program error.. " + e.Message);
                Console.WriteLine("================================================");
            }
            Console.ReadKey();
        }

    }
}