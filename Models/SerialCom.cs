using System.IO.Ports;
using System.Text;

namespace SerialCommunication.Models
{
    class SerialCom
    {
        public static SerialPort serialPort = new SerialPort();

        public static void SerialOpen(string port,int baudrate)
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

        public static void SerialClose()
        {
            if (serialPort.IsOpen)
            {
                serialPort.Close();
            }
        }

        public static void SendData(string sendData)
        {
            if (serialPort.IsOpen)
            {
                serialPort.Write(sendData);
            }
        }

        public static string RecieveData()
        {
            if (serialPort.IsOpen)
            {
                return serialPort.ReadExisting();
            }
            else
            {
                return string.Empty;
            }
        }

        public static void BuffClear()
        {
            if (serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
            }
        }
    }
}
