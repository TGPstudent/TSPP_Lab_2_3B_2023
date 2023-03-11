//TSPP_Lab_2_3B_2023 Сума від'ємних елементів та добуток елементів між max та min в згенерованому масиві.
using System;

namespace TSPP_Lab_2_3B_2023
{
    class Program
    {
        public static void ArgGenerator(int[] A)//Генерування елементів вектору
        {
            int min = -100, max = 100;
            Random ri = new Random();
            for (int i = 0; i < A.Length; ++i)
            A[i] = ri.Next(min, max);
        }
        public static int ArgSumMines(int[] A)// сума від'ємних елементів
        {
            int sum = 0;
            foreach (int elem in A)
                if (elem < 0) sum += elem;
            return (sum);
        }
        public static long ArgDobMinOrMax(int[] A)// добуток елементiв мiж мах i мin
        {
            int max = A[0];
            int min = A[0];
            foreach (int elem in A)
            {
                if (elem > max) max = elem;
                else if (elem < min) min = elem;
            }
            Console.WriteLine($"2 Мiнiмальний елемент вектору min={min}, максимальний max= {max}");
            int imax = Array.IndexOf(A, max);
            int imin = Array.IndexOf(A, min);
            long dob = 1;
            if (imin < imax && imax - imin > 2)
                for (int i = imin + 1; i < imax; i++)
                    dob = dob * A[i];
            else if (imin > imax && imin - imax > 2)
                for (int i = imax + 1; i < imin; i++)
                    dob = dob * A[i];
            return dob;
        }
        static void Main(string[] args)
        {
            uint n;
            Console.Write("\n Введiть кiлькiсть елементiв вектора N=");
            string TN = Console.ReadLine();
            n = uint.Parse(TN);
            int[] A = new int[n];
            ArgGenerator(A);
            //Виведення результатiв
            Console.Clear();
            Console.Write("\n Згенеровано вектор A[" + $"{n}" + "]={");
            foreach (int elem in A)
                Console.Write($"{elem}" + ", ");
            Console.WriteLine("\b\b}\n");
            int sum = ArgSumMines(A);
            if (sum != 0) Console.WriteLine($"1 Сума вiд'ємних елементiв вектору дорiвнює {sum}\n");
            else Console.WriteLine("1 Вiд'ємнi елементи вiдсутнi в заданому векторi, сумувати нічого\n");

            long dob = ArgDobMinOrMax(A);
            if (dob != 1) Console.WriteLine($" Добуток елементiв мiж максимальним i мiнiмальним дорiвнює {dob}");
            else Console.WriteLine(" Мiнiмальний та максимальний елементи вектору розташованi поруч, \n мiж ними менше двох елементiв, обрахунок добутку немає сенсу"); ;
            Console.ReadLine();
        }
    }
}

