using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SynchronousSocketClient
{

    public static void StartClient()
    {
        // Buffer de dados do dado recebido.  
        byte[] bytes = new byte[1024];

        // Conectara a um servidor remoto.  
        try
        {
            //Estabelece um endpoint remoto para o socket.
            //Esse exemplo usa  porta 11000 no computador local.
            
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

            // Cria um socket TCP/IP.  
            Socket sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            
            //Conecta um socket ao endpoint remoto.Pega qualquer erro.
            try
            {
                sender.Connect(remoteEP);

                Console.WriteLine("Socket conectado ao {0}",
                    sender.RemoteEndPoint.ToString());

                
                //Codifica a string de dados num array.
                byte[] msg = Encoding.ASCII.GetBytes("Isso eh um teste<EOF>");

                //Envia o dado pelo socket.
                int bytesSent = sender.Send(msg);

                  
                //Recebe a resposta do dispositivo remoto.
                int bytesRec = sender.Receive(bytes);
                Console.WriteLine("Teste = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec));

                // Lança o socket 
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }
            catch (ArgumentNullException ane)
            {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
            }
            catch (SocketException se)
            {
                Console.WriteLine("SocketException : {0}", se.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Exceção inesperada : {0}", e.ToString());
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
        }
    }

    public static int Main(String[] args)
    {
        StartClient();
        return 0;
    }
}
