using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace CraftLR.Workshop5;

#pragma warning disable CA1416

public static class Program
{
    public static void Main()
    {
    // Créer un processus et le lancer
        Process processus1 = Process.Start("ls");
        Console.WriteLine("Processus " + processus1.Id + " est lancé !");

    // Endormir le programme principal pour attendre le lancement du processus puis continuer
    //    Thread.Sleep(2000);

    // Attente 2 secondes avant de quitter
        processus1.WaitForExit(2000);

    // Création du deuxième processus avec une autre méthode
    // NEW ! Utilisation de StartInfo, FileName et Arguments
        Process processus2 = new Process();
        processus2.StartInfo.FileName = "cat";
        processus2.StartInfo.Arguments = "Chien_et_chat.txt";
        processus2.Start();
        Console.WriteLine("Processus " + processus2.Id + " est lancé !");
        EventHandler(Exithandler) handler = ThresholdReached;
            if (handler != null)
            {
                handler(this, e);
            }

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
}