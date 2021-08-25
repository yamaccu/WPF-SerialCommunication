using System.IO.Ports;
using System.Text;

namespace SerialCommunication.Models
{
    class SerialCom
    {
        public static SerialPort serialPort = new SerialPort();

        public static void StartListening(string port,int baudrate)
        {
            serialPort.PortName = port;
            serialPort.BaudRate = baudrate;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.WriteTimeout = 1000;
            serialPort.ReadTimeout = 1000;
            serialPort.Encoding = Encoding.UTF8;

            serialPort.Open();
        }

        public static void StopListening()
        {
            serialPort.Close();
        }

        public static void WriteData(string data)
        {
            serialPort.Write(data);
        }

        public static string ReadData()
        {
            return serialPort.ReadExisting();
        }
    }
}
