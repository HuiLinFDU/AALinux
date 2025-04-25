using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
// Client app is the one sending messages to a Server/listener.
// Both listener and client can send messages back and forth once a
// communication is established.
public class SocketClient {
public static int Main(String[] args)  {
        StartClient();
        return 0;
     }
    public static void StartClient() {
        byte[] bytes = new byte[1024];   
        try  {
            // Connect to a Remote server
            // Get Host IP Address that is used to establish a connection
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1
            // If a host has multiple addresses, you will get a list of addresses
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);
// Create a TCP/IP  socket.
            Socket sender = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            // Connect the socket to the remote endpoint. Catch any errors.
            try {
                // Connect to Remote EndPoint
                sender.Connect(remoteEP);
#pragma warning disable CS8602 // 解引用可能出现空引用。
                Console.WriteLine("Socket connected to {0}",
                     sender.RemoteEndPoint.ToString());
#pragma warning restore CS8602 // 解引用可能出现空引用。

                // Encode the data string into a byte array.  Assignment 10/05 :for message 1.
                byte[] msg1 = Encoding.ASCII.GetBytes("CSCI6751 Artificial Intelligence<EOF>");
                // Send the data through the socket.
                int bytesSent1 = sender.Send(msg1);
                // Receive the response from the remote device.
                int bytesRec1 = sender.Receive(bytes);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec1));

                // Encode the data string into a byte array.  Assignment 10/05 :for message 2.
                byte[] msg2 = Encoding.ASCII.GetBytes("CSCI7850 User Interface<EOF>");
                // Send the data through the socket.
                int bytesSent2 = sender.Send(msg2);
                // Receive the response from the remote device.
                int bytesRec2 = sender.Receive(bytes);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec2));

                // Encode the data string into a byte array.  Assignment 10/05 :for message 3.
                byte[] msg3 = Encoding.ASCII.GetBytes("CSCI7645 System Programming<EOF>");
                // Send the data through the socket.
                int bytesSent3 = sender.Send(msg3);
                // Receive the response from the remote device.
                int bytesRec3 = sender.Receive(bytes);
                Console.WriteLine("Echoed test = {0}",
                    Encoding.ASCII.GetString(bytes, 0, bytesRec3));

                // Release the socket.
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();}
            catch (ArgumentNullException ane) {
                Console.WriteLine("ArgumentNullException : {0}", ane.ToString());  }
            catch (SocketException se)  {
                Console.WriteLine("SocketException : {0}", se.ToString());  }
            catch (Exception e){
                Console.WriteLine("Unexpected exception : {0}", e.ToString());
            }
         }
        catch (Exception e)  {
            Console.WriteLine(e.ToString());
        }
     }
}


