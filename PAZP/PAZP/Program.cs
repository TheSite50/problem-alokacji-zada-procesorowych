using System;
using System.Linq;

//program plecakowy
//program procesorów
//problem komiwojażera



namespace PAZP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //liczba iteracji
            //zrób array wejściowy
            //zsumiuj wartośćio
            //wylosuj nr komórki i nr jak tam wejdzie
            //porównaj
            //ten który ma mniejszy max przechodzi dalej
            Console.WriteLine("How Many Iterations?: ");
            int iter = int.Parse(Console.ReadLine());
            Console.WriteLine("How Many Processes?: ");
            int ProcessCount = int.Parse(Console.ReadLine());
            int[] parent = new int[ProcessCount];
            Console.WriteLine("How Many Processors?: ");
            int ProcessorNumber = int.Parse(Console.ReadLine());
            Random rnd = new Random();
            int[] sums = new int[ProcessorNumber];
            for (int i = 0; i < ProcessCount; i++) 
            {
                int curProc = rnd.Next(ProcessorNumber);
                parent[i] = curProc;
                sums[curProc] += i;
                Console.Write(parent[i] + " ");
            }
            Console.Write(sums.Max());
            Console.WriteLine();
            //100
            for (int i = 0; i < iter; i++)
            {
                int next = rnd.Next(ProcessCount); //pozycja
                int nextVal = rnd.Next(ProcessorNumber); //który procesor
                int[] childSum = (int[])sums.Clone();
                childSum[parent[next]] -= next;
                childSum[nextVal] += next;
                if(childSum.Max() < sums.Max()) 
                {
                    sums[parent[next]] -= next;
                    sums[nextVal] += next;
                    parent[next] = nextVal;
                }
            }
            foreach (int i in parent) 
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(sums.Max());
            Console.ReadKey();
        }
    }
}
