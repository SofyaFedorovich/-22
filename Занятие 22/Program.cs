using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;



namespace Занятие_22
{ //массив случайных чисел с задачей продолжения
    class Program
    {
        static int[] m; //массив
        static void Main(string[] args)
        {
            Console.Write("Введите размерность массива: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            m = new int[n];
            Console.Write("Массив чисел: ");
            for (int i = 0; i < n; i++)
            {
                m[i] = random.Next(0, 100);
                Console.Write($"{m[i]}\t");
                Thread.Sleep(10);
            }
            Console.WriteLine();
            Task task1 = new Task(Sum);
            Task task2 = task1.ContinueWith(Max); //задача продолжения
            task1.Start();
            task2.Wait();
            Console.ReadKey();

        }
        static void Sum() // метод для вычисления суммы чисел в массиве
        {
            int[] array = m;
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += m[i];
            }
            Console.WriteLine($"Сумма чисел массива: {sum}");
        }
        static void Max(Task task) //метод для нахождения максимального числа в массиве
        {
            int[] array = m;
            int max = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (m[i] > max)
                {
                    max = m[i];
                }
            }
            Console.WriteLine($"Максимальное число в массиве: {max}");
        }
    }
}
