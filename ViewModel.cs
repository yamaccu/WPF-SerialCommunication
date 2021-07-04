using System;
using System.Collections.Generic;
using System.Text;
using Reactive.Bindings;
using System.Collections.ObjectModel;
using System.IO.Ports;
using SerialCommunication.Models;
using System.Windows;

namespace SerialCommunication
{
    class ViewModel
    {
        public ReactiveCollection<string> COMPorts { get; set; } = new ReactiveCollection<string>();
        public ReactiveCollection<int> COMBaudrate { get; set; } = new ReactiveCollection<int>();
        public ReactiveProperty<string> SelectedPort { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<int> SelectedBaudrate { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<string> TXData { get; set; } = new ReactiveProperty<string>("");
        public ReactiveProperty<string> RXData { get; set; } = new ReactiveProperty<string>("");

        public ViewModel()
        {
            SetCOMBaudrateComboBox();
        }

        public void ScanCOMPorts()
        {
            COMPorts.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                COMPorts.Add(port);
            }
        }

        private void SetCOMBaudrateComboBox()
        {
            COMBaudrate.Add(1200);
            COMBaudrate.Add(2400);
            COMBaudrate.Add(4800);
            COMBaudrate.Add(9600);
            COMBaudrate.Add(19200);
            COMBaudrate.Add(38400);
            COMBaudrate.Add(57600);
            COMBaudrate.Add(115200);
        }

        public void SerialOpen()
        {
            try
            {
                SerialCom.SerialOpen(SelectedPort.Value, SelectedBaudrate.Value);
                SerialCom.serialPort.DataReceived += OnReceived;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SerialClose()
        {
            if (SerialCom.serialPort.IsOpen)
            {
                SerialCom.SerialClose();
            }
        }

        public void SendData()
        {
            if (SerialCom.serialPort.IsOpen)
            {
                SerialCom.SendData(TXData.Value);
                TXData.Value = string.Empty;
            }
        }
        private void OnReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RXData.Value += SerialCom.RecieveData();
        }

        public void RXDataClear()
        {
            RXData.Value = String.Empty;
        }
    }
}
