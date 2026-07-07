using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_money
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float num;
            float num1;
            float res = 0;
            Console.Write("Введите первое чсило: ");
            num=Convert.ToSingle(Console.ReadLine());
            Console.Write("Введите второе число: ");
            num1=Convert.ToSingle(Console.ReadLine());
            res = num + num1;
            Console.Write($"Сумма ваших чисел: {res}");

        }
       


    }

}
