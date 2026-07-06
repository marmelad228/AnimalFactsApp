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
            int healt;
            int armor;
            int damage;
            Console.Write("Введите ваше здоровье: ");
            healt = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите вашу броню: ");
            armor = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ввам нанесли: ");
            damage = Convert.ToInt32(Console.ReadLine());
            healt -= damage * armor / 100;
            Console.WriteLine($"У вас осталась {healt} здоровья");

        }
       


    }

}
