using System;
using System.Security.Cryptography;
using System.Text;

namespace Sensor
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = "localhost";
            int port = 19374;
            while (true)
            {
                string GH = " ";
                Console.WriteLine("Listo....");
                Console.ReadKey();
                GH=GETMessage(host, port);
                if (GH!=" ")
                {
                    PUTMessage(GH, host, port);
                }
                else
                {
                    Console.WriteLine("Error de conexion intente de nuevo");
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

            if (InformeR[1] == "200") { Console.WriteLine("OK"); }
            else { Console.WriteLine("NOK"); }
        }


        static string GETMessage(string host, int port)
        {
            string FYH = " ";
            try
            {
                
                //connect
                var client = new System.Net.Sockets.TcpClient();
                //Send
                client.Connect(host, port);
                string MessageS = "GET /Device/GetDateTime/99 HTTP/1.1\r\n" +
                "Host:"+ host+":"+port.ToString()+"\r\n" + 
                "\r\n";


                byte[] datOut = Encoding.UTF8.GetBytes(MessageS);
                client.GetStream().Write(datOut, 0, datOut.Length);
                //Espera
                System.Threading.Thread.Sleep(1000);
                //rec
                if (client.Available > 0)
                {
                    byte[] datIn = new byte[client.Available];
                    client.GetStream().Read(datIn, 0, datIn.Length);
                    string responce = Encoding.UTF8.GetString(datIn);
                    Console.WriteLine("Respuesta: \r\n" + responce);
                    var Mensaje = responce.Split(new string[] { "\r\n\r\n" }, StringSplitOptions.None);
                    var body = Mensaje[1];
                    Analisis(responce);
                    FYH = body;
                    Console.WriteLine("FYH:"+FYH+ "\r\n");
                }
                else
                {
                    Console.WriteLine("No hay Respuesta GET: \r\n");
                }


                //Disconect
                client.Close();
                return FYH;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return FYH;
        }

        static void PUTMessage(string Date, string host, int port)
        {
            try
            {
                
                var ran = new Random();

                float ValueSensor = (float)ran.NextDouble();


                string Variable = "MEDICION=" + ValueSensor.ToString() + "&" + "FECHAYHORA=" + Date.ToString();

                
                //connect
                var client = new System.Net.Sockets.TcpClient();
                //Send
                client.Connect(host, port);
                string MessageS = "PUT /Device/PutData/99 HTTP/1.1\r\n" +
                "Host:"+host+":"+port.ToString()+"\r\n" +
                "Content-Type: application/x-www-form-urlencoded\r\n" +
                "Content-Length:" + Variable.Length.ToString() + "\r\n" +
                "\r\n" + Variable;


                byte[] datOut = Encoding.UTF8.GetBytes(MessageS);
                client.GetStream().Write(datOut, 0, datOut.Length);
                //Espera
                System.Threading.Thread.Sleep(1000);
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
                    Console.WriteLine("No hay Respuesta PUT: \r\n");
                }


                //Disconect
                client.Close();
                Console.WriteLine("Fin de la conexion \r\n");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
