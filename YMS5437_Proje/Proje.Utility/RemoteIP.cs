using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Proje.Utility
{
    public static class RemoteIP
    {
        /// <summary>
        /// Ekle/Sil/Güncelle İşlemlerinde Kişinin Lokal Ip Adresini String Tipte Yakalamızı Sağlar.
        /// </summary>
        /// <returns></returns>
        private static string GetIpAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            return "Local IP Address Not Found!";
        }

        public static string IpAddress { get => GetIpAddress(); }
    }
}
