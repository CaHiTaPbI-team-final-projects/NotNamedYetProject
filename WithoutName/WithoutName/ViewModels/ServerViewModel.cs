using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using WithoutName.Commands;
using WithoutName.Models;
using WithoutName.Views;
using System.Windows;
using WithoutName.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace WithoutName.ViewModels
{
    public class ServerViewModel : INotifyPropertyChanged
    {

        int port;
        IPAddress addr;
        IPEndPoint ep;
        TcpClient client;











        public ServerViewModel()
        {
            port = 15228;
            addr = IPAddress.Parse("127.0.0.1");
            ep = new IPEndPoint(addr, port);
        }



        public string CommandToServer (Params p)
        {
            try
            {
                client = new TcpClient();
                client.Connect(ep);
                NetworkStream ns = client.GetStream();
                StreamWriter writer = new StreamWriter(ns);
                string request = "";
                for (int i = 0; i < p.t.Count; i++)
                {
                    if(i != 0)
                    {
                        request += ";";
                    }
                    request += $"{p.t[i]}";
                }
                writer.WriteLine($"");
                writer.Flush();


                string buff;



                //BinaryReader(new BufferedStream(stream));
                StreamReader reader = new StreamReader(ns);
                buff = reader.ReadLine();
                MessageBox.Show("Получен ответ: " + buff);





                reader.Close();
                writer.Close();
                ns.Close();
                client.Close();
                return buff;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "An error occured when we are sending message");
                return null;

            }
        }

        //public string CommandToServer (string operation, string var1)
        //{
        //    try
        //    {
        //        client = new TcpClient();
        //        client.Connect(ep);
        //        NetworkStream ns = client.GetStream();

        //        StreamWriter writer = new StreamWriter(ns);
        //        writer.WriteLine($"{operation};{var1}");
        //        writer.Flush();


        //        string buff;



        //        //BinaryReader(new BufferedStream(stream));
        //        StreamReader reader = new StreamReader(ns);
        //        buff = reader.ReadLine();
        //        MessageBox.Show("Получен ответ: " + buff);

                



        //        reader.Close();
        //        writer.Close();
        //        ns.Close();
        //        client.Close();
        //        return buff;
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message, "An error occured when we are sending message");
        //        return null;

        //    }
        //}

        //public string CommandToServer(string operation, string var1,string var2)
        //{
        //    try
        //    {
        //        client = new TcpClient();
        //        client.Connect(ep);
        //        NetworkStream ns = client.GetStream();

        //        StreamWriter writer = new StreamWriter(ns);
        //        writer.WriteLine($"{operation};{var1};{var2}");
        //        writer.Flush();


        //        string buff;



        //        //BinaryReader(new BufferedStream(stream));
        //        StreamReader reader = new StreamReader(ns);
        //        buff = reader.ReadLine();
        //        MessageBox.Show("Получен ответ: " + buff);





        //        reader.Close();
        //        writer.Close();
        //        ns.Close();
        //        client.Close();
        //        return buff;
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message, "An error occured when we are sending message");
        //        return null;
        //    }
        //}

        //public string CommandToServer(string operation, string var1, string var2, string var3)
        //{
        //    try
        //    {
        //        client = new TcpClient();
        //        client.Connect(ep);
        //        NetworkStream ns = client.GetStream();

        //        StreamWriter writer = new StreamWriter(ns);
        //        writer.WriteLine($"{operation};{var1};{var2};{var3}");
        //        writer.Flush();


        //        string buff;



        //        //BinaryReader(new BufferedStream(stream));
        //        StreamReader reader = new StreamReader(ns);
        //        buff = reader.ReadLine();
        //        MessageBox.Show("Получен ответ: " + buff);





        //        reader.Close();
        //        writer.Close();
        //        ns.Close();
        //        client.Close();
        //        return buff;
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message, "An error occured when we are sending message");
        //        return null;
        //    }
        //}


        //public string CommandToServer(string operation, string var1, string var2, string var3, string var4)
        //{
        //    try
        //    {
        //        client = new TcpClient();
        //        client.Connect(ep);
        //        NetworkStream ns = client.GetStream();

        //        StreamWriter writer = new StreamWriter(ns);
        //        writer.WriteLine($"{operation};{var1};{var2};{var3};{var4}");
        //        writer.Flush();


        //        string buff;



        //        //BinaryReader(new BufferedStream(stream));
        //        StreamReader reader = new StreamReader(ns);
        //        buff = reader.ReadLine();
        //        MessageBox.Show("Получен ответ: " + buff);





        //        reader.Close();
        //        writer.Close();
        //        ns.Close();
        //        client.Close();
        //        return buff;
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show(err.Message, "An error occured when we are sending message");
        //        return null;
        //    }
        //}









        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
