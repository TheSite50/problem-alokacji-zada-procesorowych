using System;
using System.Linq;

//program plecakowy
//program procesorów
//problem komiwojażera


//liczba iteracji
//zrób array wejściowy
//zsumiuj wartośćio
//wylosuj nr komórki i nr jak tam wejdzie
//porównaj
//ten który ma mniejszy max przechodzi dalej

namespace PAZP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Pobieranie liczby iteracji, procesów i procesorów od użytkownika
            Console.WriteLine("How Many Iterations?: ");
            int iterations = int.Parse(Console.ReadLine());

            Console.WriteLine("How Many Processes?: ");
            int tasks = int.Parse(Console.ReadLine());
            int[] taskArr = new int[tasks];

            Console.WriteLine("How Many Processors?: ");
            int workers = int.Parse(Console.ReadLine());
            double[] workerSum = new double[workers];

            // Tablica wag dla procesorów
            double[] weights = { 1.0, 1.25, 1.5, 1.75 };

            Random rnd = new Random();

            // Przydzielanie procesów do losowych procesorów
            for (int i = 0; i < tasks; i++)
            {
                int currentWorker = rnd.Next(workers);
                taskArr[i] = currentWorker;
                workerSum[currentWorker] += i * weights[currentWorker];
                Console.Write(taskArr[i] + " ");
            }
            Console.Write(workerSum.Max());
            Console.WriteLine();

            // Główna pętla iteracji
            for (int i = 0; i < iterations; i++)
            {
                // Wybór losowego zadania
                int taskToBeSwapped = rnd.Next(tasks);

                // Wybór losowego pracownika
                int workerToBeInserted = rnd.Next(workers);

                // Kopiowanie tablicy
                double[] childSum = (double[])workerSum.Clone();

                childSum[taskArr[taskToBeSwapped]] -= taskToBeSwapped * weights[taskArr[taskToBeSwapped]];
                childSum[workerToBeInserted] += taskToBeSwapped * weights[workerToBeInserted];

                // Aktualizacja jeśli nowy rozkład jest lepszy
                if (childSum.Max() < workerSum.Max())
                {
                    workerSum[taskArr[taskToBeSwapped]] -= taskToBeSwapped * weights[taskArr[taskToBeSwapped]];
                    workerSum[workerToBeInserted] += taskToBeSwapped * weights[workerToBeInserted];
                    taskArr[taskToBeSwapped] = workerToBeInserted;
                }
            }

            // Wypisanie wyniku
            foreach (int i in taskArr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine(workerSum.Max());
            Console.ReadKey();
        }
    }
}


/*
namespace PAZP
{
internal class Program
{
static void Main(string[] args)
{

//ces => proCESs    task
//sor => procesSOR  worker
//par => PARent


// Pobieranie liczby iteracji, procesów i procesorów od użytkownika
Console.WriteLine("How Many Iterations?: ");
int iterations = int.Parse(Console.ReadLine());

Console.WriteLine("How Many Processes?: ");
int tasks = int.Parse(Console.ReadLine());
int[] taskArr = new int[tasks];

Console.WriteLine("How Many Processors?: ");
int workers = int.Parse(Console.ReadLine());
double[] workerSum = new double[workers];

// Tablica wag dla procesorów
double[] weights = { 1.0, 1.25, 1.5, 1.75 };

Random rnd = new Random();

// Przydzielanie procesów do losowych procesorów
for (int i = 0; i < tasks; i++) 
{
    int currentWorker = rnd.Next(workers);
    taskArr[i] = currentWorker;
    workerSum[currentWorker] += i * weights[currentWorker];
    Console.Write(taskArr[i] + " ");
}
Console.Write(workerSum.Max());
Console.WriteLine();
//100
for (int i = 0; i < iterations; i++)
{
    //select position
    int TaskToBeSwapped = rnd.Next(tasks);
    //select processor
    int WorkerToBeInserted = rnd.Next(workers);
    //copy the array
    double[] childSum = (double[])workerSum.Clone();

    childSum[taskArr[TaskToBeSwapped]] -= TaskToBeSwapped * weights[taskArr[TaskToBeSwapped]];
    childSum[WorkerToBeInserted] += TaskToBeSwapped * weights[WorkerToBeInserted];

    if(childSum.Max() < workerSum.Max()) 
    {
        workerSum[taskArr[TaskToBeSwapped]] -= TaskToBeSwapped * weights[taskArr[TaskToBeSwapped]];
        workerSum[WorkerToBeInserted] += TaskToBeSwapped * weights[WorkerToBeInserted];
        taskArr[TaskToBeSwapped] = WorkerToBeInserted;
    }
}
//wypisanie wyniku
foreach (int i in taskArr) 
{
    Console.Write(i + " ");
}
Console.WriteLine(workerSum.Max());
Console.ReadKey();
}
}
}
*/