﻿using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketListener
{

    //Dados vindos do cliente.  
    public static string data = null;

    public static void StartListening()
    {
        //Buffer de dados para dados vindos. 
        byte[] bytes = new Byte[1024];

        //Estabelece o endpoint local para o socket.  
        // Dns.GetHostName retorna o nome do 
        // host rodando a aplicação.  
        IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
        IPAddress ipAddress = ipHostInfo.AddressList[0];
        IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

        // Cria um socket TCP/IP.  
        Socket listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);

        // Liga o socket com o endpoint local e    
        // "ouve" conexões futuras.  
        try
        {
            listener.Bind(localEndPoint);
            listener.Listen(10);

            // Começa a esperar por conexões.  
            while (true)
            {
                Console.WriteLine("Esperando conexão...");
                
                //Programa é suspenso enquanto espera por uma conexão.
                Socket handler = listener.Accept();
                data = null;

                //Uma conexão precisa ser processada.
                 
                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                //Mostra os dados no console. 
                Console.WriteLine("Texto recebido : {0}", data);

                // Escreve o dado de volta para o cliente.  
                byte[] msg = Encoding.ASCII.GetBytes(data);

                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }

        Console.WriteLine("\nPressione ENTER para continuar...");
        Console.Read();

    }

    public static int Main(String[] args)
    {
        StartListening();
        return 0;
    }
}