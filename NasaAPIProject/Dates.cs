using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace NasaAPIProject
{
    class Dates
    {
        ReadFiles readFiles = new ReadFiles();
        public List<string> getDates()
        {
            List<string> selectedDates = new List<string>();
            var AppSettings = ConfigurationManager.AppSettings;
            string filePath = AppSettings["Path"] + AppSettings["FileName"];
            var mylist = readFiles.readtxtFileLines(filePath);
            foreach (var item in mylist)
            {
                DateTime temp;
                if (DateTime.TryParse(item, out temp))
                {
                    selectedDates.Add(Convert.ToDateTime(item).ToString("yyyy-MM-dd"));
                }
                else
                {
                    Console.WriteLine(String.Format("{0} is invalid date.", item));
                }
             }
            return selectedDates;
        }
    }
}
