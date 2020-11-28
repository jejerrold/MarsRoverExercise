using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NasaAPIProject
{
    class ReadFiles
    {
        public List<string> readtxtFileLines(string filePath)
        {
            List<string> txtLines = new List<string>();
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
               txtLines.Add(line.Trim());
            }
            return txtLines;
        }
    }
}
