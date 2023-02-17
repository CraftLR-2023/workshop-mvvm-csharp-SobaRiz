using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace CraftLR.Workshop6;

public static class Program
{
    private static readonly object C1 = new object();
    private static readonly object T1 = new object();
    private static readonly object C2 = new object();
    private static readonly object T2 = new object();
    private static int pieces;
    private static int p1;
    private static int p2;
    private static int p3;
    private static int p4;
    private static Stopwatch timer = new Stopwatch();

    public static void Main(string[] _)
    {
        Console.WriteLine("Thread principal débute");

        // Mettre le temps en action
        timer.Start();

        // CREATING THREADS
        Thread y1 = new Thread(Ouvrier1);
        Thread y2 = new Thread(Ouvrier2);
        Thread y3 = new Thread(Ouvrier3);
        Thread y4 = new Thread(Ouvrier4);

        pieces = 0;
        p1 = 0;
        p2 = 0;
        p3 = 0;
        p4 = 0;

        // EXECUTE THREADS
        y1.Start();
        y2.Start();
        y3.Start();
        y4.Start();

        // Le Thread principal attendra que tous les programmes en cours (ceux suivis de join) soit fini pour se finir
        y1.Join();
        y2.Join();
        y3.Join();
        y4.Join();
        Console.WriteLine("Thread principal fini");

        // Stopper le temps en action
        timer.Stop();
        TimeSpan timeTaken = timer.Elapsed;

        Console.WriteLine("Temps écoulé : " + timeTaken);
        Console.WriteLine("Pièces fabriquées : " + pieces);
        Console.WriteLine("[Ouvrier 1 : " + p1 + "| Ouvrier 2 : " + p2 + "]");
        Console.WriteLine("[Ouvrier 3 : " + p3 + "| Ouvrier 4 : " + p4 + "]");
        Console.Read();
    }

    private static void Ouvrier1()
    {
        while (timer.ElapsedMilliseconds < 80)
        {
            lock (C1)
            {
                lock (T1)
                {
                    Console.WriteLine("L'ouvrier 1 " + Thread.CurrentThread.Name + $" attrape clé à molette 1 et tournevis 1 ");
                    Thread.Sleep(4);
                    pieces++;
                    p1++;
                    Console.WriteLine("L'ouvrier 1 pose ses outils. Ses pieces : [" + p1 + "]");
                }
            }
        }
    }

    private static void Ouvrier2()
    {
        while (timer.ElapsedMilliseconds < 80)
        {
            lock (T1)
            {
                lock (C2)
                {
                    Console.WriteLine("L'ouvrier 2 " + Thread.CurrentThread.Name + $" attrape clé à molette 2 et tournevis 1 ");
                    Thread.Sleep(4);
                    pieces++;
                    p2++;
                    Console.WriteLine("L'ouvrier 2 pose ses outils. Ses pieces : [" + p2 + "]");
                }
            }
        }
    }

    private static void Ouvrier3()
    {
        while (timer.ElapsedMilliseconds < 80)
        {
            lock (C2)
            {
                lock (T2)
                {
                    Console.WriteLine("L'ouvrier 3 " + Thread.CurrentThread.Name + $" attrape clé à molette 2 et tournevis 2 ");
                    Thread.Sleep(4);
                    pieces++;
                    p3++;
                    Console.WriteLine("L'ouvrier 3 pose ses outils. Ses pieces : [" + p3 + "]");
                }
            }
        }
    }

    private static void Ouvrier4()
    {
        while (timer.ElapsedMilliseconds < 80)
        {
            lock (C1)
            {
                lock (T2)
                {
                    Console.WriteLine("L'ouvrier 4 " + Thread.CurrentThread.Name + $" attrape clé à molette 1 et tournevis 1 ");
                    Thread.Sleep(4);
                    pieces++;
                    p4++;
                    Console.WriteLine("L'ouvrier 4 pose ses outils. Ses pieces : [" + p4 + "]");
                }
            }
        }
    }
}