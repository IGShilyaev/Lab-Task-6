using System;
using System.Collections.Generic;
using System.Globalization;

namespace Pract_Task_6
{
    class Program
    {
        static void Main(string[] args)
        {
            double a1, a2, a3;

            Console.WriteLine("Введите первое число последовательности");
            a1 = EnterDoubleNumber();
            Console.WriteLine("Введите второе число последовательности");
            a2 = EnterDoubleNumber();
            Console.WriteLine("Введите третье число последовательности");
            a3 = EnterDoubleNumber();

            Console.WriteLine("Введите количество необходимых нечетных элементов (>1)");
            int N = EnterIntNumber();

            List<double> arr = FormArr(a1, a2, a3 ,N);
            Console.WriteLine("Сформирована последовательность:");
            foreach (double x in arr) Console.Write(x + "; ");


            double[] oddElems = new double[N];
            OddNumElems(ref oddElems, arr, 0, 0);

            bool res = CheckMono(oddElems);
            Console.WriteLine();
            if (res) Console.WriteLine("Элементы с нечетными номерами образуют монотонную последовательность");
            else Console.WriteLine("Элементы с четными номерами не образуют монотонную последовательность");

        }

        static bool CheckMono(double[] arr)
        {
            for(int i = 0, j = 1, k=2; k<arr.Length; i++, j++, k++)
            {
                if (arr[i] == arr[j] || arr[j] == arr[k]) continue;
                if ((arr[i] < arr[j]) != (arr[j] < arr[k])) return false;
            }
            return true;
        }

        static void OddNumElems(ref double[] mainArr, List<double> prevArr, int i, int j)
        {
            if (j > prevArr.Count) return;
            if ((j+1)%2>0) { mainArr[i] = prevArr[j]; i++; }
            j++;
            OddNumElems(ref mainArr, prevArr, i, j);
        }
        

        static List<double> FormArr(double a1, double a2, double a3 ,int N)
        {
            List<double> temp = new List<double>();
            temp.Add(a1);
            temp.Add(a2);
            temp.Add(a3);
            int odds = 2;
            int tekElement = 3;
            while (odds < N)
            {
                double newelem = 0.7 * temp[tekElement - 1] - 0.2 * temp[tekElement - 2] + (tekElement - 1) * temp[tekElement - 3];
                temp.Add(newelem);
                tekElement++;
                if (tekElement % 2 > 0) odds++;
            }
            return temp;
        }

        static int EnterIntNumber()
        {
            bool ok = false;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n) && (n > 1);
                if (!ok) Console.Write("Ошибка! Не удалось преобразовать в натуральное число, превышающее 1. Введите значение заново: ");
            } while (!ok);
            return n;
        }

        static double EnterDoubleNumber()
        {
            bool ok = false;
            double n;
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n);
                if (!ok) { Console.Write("Ошибка! Не удалось преобразовать введенное значение в вещественное число. Введите другое значение: "); }
            } while (!ok);
            return n;
        }
    }
}
