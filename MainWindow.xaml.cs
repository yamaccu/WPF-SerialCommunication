using System;
using System.Windows;

namespace SerialCommunication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel viewModel = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void ComboBoxDropDownOpened_COMPort(object sender, EventArgs e)
        {
            viewModel.GetCOMPorts();
        }

        private void ButtonClick_Open(object sender, RoutedEventArgs e)
        {
            viewModel.SerialOpen();
        }

        private void ButtonClick_Close(object sender, RoutedEventArgs e)
        {
            viewModel.SerialClose();
        }

        private void ButtonClick_Send(object sender, RoutedEventArgs e)
        {
            viewModel.Send();
        }

        private void ButtonClick_Clear(object sender, RoutedEventArgs e)
        {
            viewModel.RXDataClear();
        }
    }
}
