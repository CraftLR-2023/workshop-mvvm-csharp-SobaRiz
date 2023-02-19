using System;
using System.Net;
using System.Net.Sockets;

namespace CraftLR.Workshop7;
public static class Serveur
{
    private static Socket SeConnecter()
    {
        Socket socketServeur = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        IPAddress hostAddress = IPAddress.Parse("0.0.0.0");
        int conPort = 8080;
        IPEndPoint hostEndPoint = new IPEndPoint(hostAddress, conPort);

        socketServeur.Bind(hostEndPoint);
        socketServeur.Listen(100);

        return socketServeur;
    }

    public static void Main(string[] _)
    {
        Socket server = SeConnecter();
    }

    public static Socket AccepterConnexion(Socket socket)
    {
        Socket socketClient = socket.Accept();
    }
}