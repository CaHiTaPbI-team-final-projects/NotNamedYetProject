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

namespace Server
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int port;
        IPAddress addr;
        IPEndPoint ep;

        Socket listener;
        Thread workThread;
        ManualResetEvent threadEvent;

        byte[] buff1 = new byte[1024];
        byte[] buff2 = new byte[1024];

        string clientMessage = String.Empty;
        string serverMessage = String.Empty;

        int receiveBytes = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                threadEvent = new ManualResetEvent(false);

                addr = IPAddress.Parse(IpBox.Text);
                port = int.Parse(PortBox.Text);
                ep = new IPEndPoint(addr, port);

                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                listener.Bind(ep);
                listener.Listen(100);

                workThread = new Thread(new ThreadStart(ThreadMethod));
                workThread.IsBackground = true;
                workThread.Start();

                Start_button.IsEnabled = false;
                StatusBox.Content = "Сосотояние сервера - включен!";
                LogBox.Text += DateTime.Now.ToString() + " -> Сервер успешно запущен! \r\n";
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка запуска сервера");
            }
        }

        void ThreadMethod()
        {
            try
            {
                while (true)
                {
                    // Socket acceptor = listener.Accept();
                    // acceptor.Receive()
                    AsyncCallback delegate1 = new AsyncCallback(AcceptCallback);
                    listener.BeginAccept(delegate1, listener);
                    threadEvent.WaitOne();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка потока");
            }

            void AcceptCallback(IAsyncResult state)
            {
                Socket listener = (Socket)state.AsyncState;
                Socket acceptor = listener.EndAccept(state);
                AsyncCallback delegate2 = new AsyncCallback(ReceiveCallback);
                acceptor.BeginReceive(buff1, 0, buff1.Length, 0, delegate2, acceptor);
            }

            // 3
            void ReceiveCallback(IAsyncResult state)
            {
                Socket acceptor = (Socket)state.AsyncState;
                receiveBytes = acceptor.EndReceive(state);
                clientMessage = Encoding.UTF8.GetString(buff1, 0, receiveBytes);

                if (clientMessage == "GET_CHAT")
                {
                    serverMessage = LogBox.Text;
                    buff2 = Encoding.UTF8.GetBytes(serverMessage);
                    AsyncCallback delegate3 = new AsyncCallback(SendCallback);
                    acceptor.BeginSend(buff2, 0, buff2.Length, 0, delegate3, acceptor);
                }
                else
                {
                    LogBox.Text += DateTime.Now.ToString() + " -> " + clientMessage + "\r\n";
                    acceptor.Shutdown(SocketShutdown.Both);
                    acceptor.Close();
                    threadEvent.Set();
                }
            }

            // 4
            void SendCallback(IAsyncResult state)
            {
                Socket acceptor = (Socket)state.AsyncState;
                acceptor.EndSend(state);
                acceptor.Shutdown(SocketShutdown.Both);
                acceptor.Close();
                threadEvent.Set();
            }
        }
    }
}
