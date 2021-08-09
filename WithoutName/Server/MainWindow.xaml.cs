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
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using Server.ControlModels;

namespace Server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServerControl sc  = new ServerControl();

        int port = 15228;
        IPAddress addr;
        IPEndPoint ep;

        TcpListener listener;

        string response="";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1");
            Thread t1 = new Thread(startListening);
            t1.Start();
            StatusBox.Content = "Сервер включен";
            Start_button.IsEnabled = false;
        }

        private void startListening() // запуск прослушки. кгб слышит все
        {
            MessageBox.Show("2");
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                listener.Start();


                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    Thread t1 = new Thread(new ParameterizedThreadStart(acceptClient));
                    t1.Start(client);

                    client.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (listener != null)
                {
                    listener.Stop();
                    Start_button.IsEnabled = true;

                }
                    
            }
        }

        private void acceptClient(object cl)
        {
            TcpClient client = (TcpClient)cl;

            NetworkStream stream = client.GetStream();

            StreamReader reader = new StreamReader(stream);
            // считываем строку из потока
            string message = reader.ReadLine();

            MessageBox.Show("Получено: " + message);

            string[] msg = message.Split(';');

            switch (msg[0])
            {
                case "ADDTRANS":
                    sc.ADDTRANS(decimal.Parse(msg[1]), int.Parse(msg[2]), int.Parse(msg[3]));
                    break;

                case "GETSTAT":
                    response = sc.GETSTAT(int.Parse(msg[1])).ToString();
                    break;
                case "ADD_USER":
                    sc.ADD_USER(msg[1], msg[2]);
                    break;

            }

            // отправляем ответ
            StreamWriter writer = new StreamWriter(stream);
            message = message.ToUpper();
            MessageBox.Show("Отправлено: " + message);
            writer.WriteLine(message);

            writer.Close();
            reader.Close();
            stream.Close();
        }

        private void Stop_button_Click(object sender, RoutedEventArgs e)
        {
            listener.Stop();
            StatusBox.Content = "Сервер выключен";
        }
    }
}
