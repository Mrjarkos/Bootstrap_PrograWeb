using System;
using System.Text;

namespace Device
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {

                    Console.WriteLine("Listo....");
                    Console.ReadKey();
                    //connect
                    var client = new System.Net.Sockets.TcpClient();
                    //Send
                    client.Connect("localhost", 19374);
                    string MessageS = "PUT /Device/PutData/99 HTTP/1.1\r\n" +
                    "Host: localhost:19374\r\n" +
                    "Content-Type: application/x-www-form-urlencoded\r\n" +
                    "Content-Length: 23\r\n" +
                    "\r\n" +
                    "Localization=Navegacion";
                    byte[] datOut = Encoding.UTF8.GetBytes(MessageS);
                    client.GetStream().Write(datOut, 0, datOut.Length);
                    //Espera
                    System.Threading.Thread.Sleep(100);
                    //rec
                    if (client.Available > 0)
                    {
                        byte[] datIn = new byte[client.Available];
                        client.GetStream().Read(datIn, 0, datIn.Length);
                        string responce = Encoding.UTF8.GetString(datIn);
                        Console.WriteLine("Respuesta: \r\n" + responce);
                        Analisis(responce);
                    }
                    else
                    {
                        Console.WriteLine("No hay Respuesta: \r\n");
                    }


                    //Disconect
                    client.Close();
                    Console.WriteLine("Fin de la conexion \r\n");

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.ReadKey();
            }

        }

        static void Analisis(string Respuesta)
        {
            var Mensaje = Respuesta.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
            var header = Mensaje[0];
            var body = Mensaje[1];

            var FieldHeader = header.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var InformeR = FieldHeader[0].Split(new char[] { ' ' });
            //var lineas = Respuesta.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //var informeR = lineas[0].Split(new char[] { ' ' });
            if (InformeR[1] == "200") { Console.WriteLine("OK"); }
            else { Console.WriteLine("NOK"); }
        }

        static void ExtarctInfo()
        {

        }
    }
}

// "PUT /Device/GetDateTime/99 HTTP/1.1\r\n" + 
// "Host:localhost:19374\r\n" + 
// "\r\n"+
//"PUT /Device/PutData/99 HTTP/1.1\r\n" +
//"Host: localhost:19374\r\n" +
//"Content-Type: application/x-www-form-urlencoded\r\n" +
//"Content-Length: 23\r\n" +
//"\r\n" +
//"Localization=Navegacion";