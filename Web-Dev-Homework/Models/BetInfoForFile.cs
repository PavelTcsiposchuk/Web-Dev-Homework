using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace Web_Dev_Homework.Models
{
    public class BetInfoForFile
    {
        public string TypeRequest { get; set; }
        public string IPClient { get; set; }
        public string UrlRequest { get; set; }

        public BetInfoForFile(string type,string ip,string url)
        {
            TypeRequest = type;
            IPClient = ip;
            UrlRequest = url;
            WriteToFile();
                
        }

        public void WriteToFile()
        {
            using (StreamWriter str = new StreamWriter("C:\\Users\\Public\\Documents\\log.txt", true, System.Text.Encoding.UTF8))//If i don`t set directory, i have exception "Отказано в доступе сохраненния файла в директорию IIS Express на диске С"
            {
                str.WriteLine("Тип запроса=" + TypeRequest+ ";IP запроса=" + IPClient+ ";Url запроса=" + UrlRequest + ";");
            }
        }

    }
}