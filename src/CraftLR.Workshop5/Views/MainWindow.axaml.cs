using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

// using Internal;
namespace CraftLR.Workshop5.Views;

#pragma warning disable CA1416

public static class MainWindow : Window
{
    public static void MainWindow()
    {
        InitializeComponent();
    }

    static Process myProcess;
    public static void Main()
    {
    // Créer un processus et le lancer
        myProcess = Process.Start("ls");
        myProcess.Exited += new EventHandler(myProcess_Exited);
        Console.WriteLine("Processus : " + myProcess.Id + " lancé !");
        Console.WriteLine("Nom : " + myProcess.ProcessName);
        Console.WriteLine("Priorité : " + myProcess.BasePriority);
        Console.WriteLine("Taille mémoire : " + myProcess.PeakVirtualMemorySize64);

        // Endormir le programme principal pour attendre le lancement du processus puis continuer
        //    Thread.Sleep(2000);

        // Attente 2 secondes avant de quitter
        myProcess.WaitForExit(2000);

    // Création du deuxième processus avec une autre méthode
    // NEW ! Utilisation de StartInfo, FileName et Arguments
        Process p2 = new Process();
        p2.StartInfo.FileName = "cat";
        p2.StartInfo.Arguments = "Chien_et_chat.txt";
        p2.Start();
        
        Console.WriteLine("Processus : " + p2.Id + " lancé !");
        Console.WriteLine("Nom : " + p2.ProcessName);
        Console.WriteLine("Priorité : " + p2.BasePriority);
        Console.WriteLine("Taille mémoire : " + p2.PeakVirtualMemorySize64);

    // Création du troisième programme avec une manière standardisée et plus propre
    // NEW ! Utilisation des Verb et UseShellExecute
        ProcessStartInfo info = new ProcessStartInfo();
        info.FileName = "cat";

        // Manière d'ouvrir de manière standardisé
        info.Verb = "Program.cs";

        // The shell should be used when starting the process
        info.UseShellExecute = true;
        Process.Start(info);

    // Endormir le programme principal pour attendre le lancement du processus puis continuer
    //    Thread.Sleep(2000);
    }
    // Handle Exited event and display process information.
    private static void myProcess_Exited(object sender, System.EventArgs e)
    {
        Console.WriteLine(
            $"Exit time    : {myProcess.ExitTime}\n" +
            $"Exit code    : {myProcess.ExitCode}\n" +
            $"Elapsed time : {Math.Round((myProcess.ExitTime - myProcess.StartTime).TotalMilliseconds)}");
        eventHandled.TrySetResult(true);
    }

}