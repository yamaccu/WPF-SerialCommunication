using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            viewModel.ScanCOMPorts();
        }

        //各イベントのコマンドバインディングは実装していない
        private void ComboBox_DropDownOpened_COMPort(object sender, EventArgs e)
        {
            viewModel.ScanCOMPorts();
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
            viewModel.SendData();
        }

        private void ButtonClick_Clear(object sender, RoutedEventArgs e)
        {
            viewModel.RXDataClear();
        }
    }
}
