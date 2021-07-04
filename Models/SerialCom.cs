using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

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
            serialPort.Open();

            serialPort.Encoding=Encoding.UTF8;
        }

        public static void SerialClose()
        {
            serialPort.Close();
        }

        public static void SendData(string sendData)
        {
            serialPort.Write(sendData);
        }

        public static string RecieveData()
        {
            return serialPort.ReadExisting();
        }

        public static void BuffClear()
        {
            serialPort.DiscardInBuffer();
        }
    }
}
