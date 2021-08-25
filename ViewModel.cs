using Reactive.Bindings;
using SerialCommunication.Models;
using System.ComponentModel;
using System;
using System.IO.Ports;
using System.Windows;

namespace SerialCommunication
{
    class ViewModel: INotifyPropertyChanged
    {
        //ReactiveProperty メモリリーク対策
        public event PropertyChangedEventHandler PropertyChanged;

        public ReactiveCollection<string> COMPorts { get; set; } = new ReactiveCollection<string>();
        public ReactiveCollection<int> Baudrates{ get; set; } = new ReactiveCollection<int>();
        public ReactiveProperty<string> SelectedPort { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<int> SelectedBaudrate { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<string> TXData { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<string> RXData { get; set; } = new ReactiveProperty<string>();
        public ReactiveProperty<bool> OpenButtonIsEnabled { get; set; } = new ReactiveProperty<bool>(true);
        public ReactiveProperty<bool> CloseButtonIsEnabled { get; set; } = new ReactiveProperty<bool>(false);
        public ReactiveProperty<bool> SendButtonIsEnabled { get; set; } = new ReactiveProperty<bool>(false);


        public ViewModel()
        {
            GetBaudrates();
        }

        public void GetCOMPorts()
        {
            COMPorts.Clear();
            string[] ports = SerialPort.GetPortNames();
            foreach (var port in ports)
            {
                COMPorts.Add(port);
            }
        }

        private void GetBaudrates()
        {
            Baudrates.Add(1200);
            Baudrates.Add(2400);
            Baudrates.Add(4800);
            Baudrates.Add(9600);
            Baudrates.Add(19200);
            Baudrates.Add(38400);
            Baudrates.Add(57600);
            Baudrates.Add(115200);
        }

        public void SerialOpen()
        {
            try
            {
                SerialCom.StartListening(SelectedPort.Value, SelectedBaudrate.Value);
                SerialCom.serialPort.DataReceived += OnReceived;
                OpenButtonIsEnabled.Value = false;
                CloseButtonIsEnabled.Value = true;
                SendButtonIsEnabled.Value = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SerialClose()
        {
            try
            {
                SerialCom.StopListening();
                OpenButtonIsEnabled.Value = true;
                CloseButtonIsEnabled.Value = false;
                SendButtonIsEnabled.Value = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Send()
        {
            if (SerialCom.serialPort.IsOpen)
            {
                SerialCom.WriteData(TXData.Value);
                TXData.Value = string.Empty;
            }
        }

        private void OnReceived(object sender, SerialDataReceivedEventArgs e)
        {
            RXData.Value += SerialCom.ReadData();
        }

        public void RXDataClear()
        {
            RXData.Value = String.Empty;
        }
    }
}
