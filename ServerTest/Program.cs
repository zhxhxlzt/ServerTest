using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerTest
{
    class Program
    {
        static void Main( string[] args )
        {
            //TcpListener listener = new TcpListener(IPAddress.Parse("192.168.1.112"), 8321);
            //listener.Start();
            //TcpClient x = listener.AcceptTcpClient();
            //Console.Write("客户端连接状态：" + x.Client.Connected.ToString());
            //byte[] byteInfo = new byte[256];
            //x.Client.Receive(byteInfo);
            //Console.Write("收到的数据长度: " + byteInfo.Length.ToString());
            //var msg = Encoding.UTF8.GetString(byteInfo);
            //Console.Write("信息：" + msg);
            //Console.ReadLine();
            Console.WriteLine("主线程ID: " + Thread.GetDomainID());
            AddAsync(1, 2);
            Thread.Sleep(1000);
            Console.ReadLine();
        }


        public static async Task<int> CountChar( int id, string address )
        {
            var wc = new WebClient();
            var result = await wc.DownloadStringTaskAsync(address);
            Console.WriteLine("调用完成");
            return result.Length;
        }


        public static async void AddAsync( int a, int b )
        {
            Console.WriteLine(" 线程ID: " + Thread.GetDomainID());
            for (int i = 0; i > -1; i++)
            {
                int sum = await Task.Run(() => a + b + i);
                //Console.WriteLine("和为: " + sum);
            }
        }
    }
}
