using System;

namespace 입출력
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = Console.ReadLine().Split(' ');
            int A = int.Parse(arr[0]);
            int B = int.Parse(arr[1]);

            Console.WriteLine(A * B);
        }
    }
}
