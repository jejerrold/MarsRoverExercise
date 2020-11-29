using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPIProject
{
    class MarsRoverHtml
    {
        List<Photos> photos = new List<Photos>();
        List<string> dates = new List<string>();
        string htmlFile;
        public MarsRoverHtml(List<Photos> loadphotos, List<string> searchdates)
        {
            photos = loadphotos;
            dates = searchdates;
            htmlFile = "MarsRover" + GetTimestamp(DateTime.Now) + ".html";
        }

        public void CreateMarsRoverWebPage()
        {
            Console.WriteLine("Creating HTML File....");
            string Html = Header();
            Html += Body();
            Html += "</html>";
            Console.WriteLine("HTML File Completed");
            OpenHTML(Html);
           
        }

        private string Header()
        {
            string header = "<html lang='en' xmlns='http://www.w3.org/1999/xhtml'>";
            header += "<head>";
            header += "<meta charset='utf-8' />";
            header += "<title></title>";
            header += "<script src='scripts/jquery.js'></script>";
            header += "<script src='scripts/bootstrap.min.js'></script>";
            header += "<script src='scripts/slick.min.js'></script>";
            header += "<link href='styles/bootstrap.min.css' rel='stylesheet' />";
            header += "<link href='styles/slick.css' rel='stylesheet' />";
            header += "<link href='styles/slick-theme.css' rel='stylesheet' />";
            header += "<link href='styles/custom.css' rel='stylesheet' />";
            header += "</head>";
            return header;
        }

        private string Body()
        {
            string body = "<body><nav class='navbar navbar-default'>";
            body += "<div class='container-fluid'>";
            body += "<div class='navbar-header'>";
            body += "<a class='navbar-brand' href='#'>";
            body += "Mars Rover Gallery";
            body += "</a>";
            body += "</div>";
            body += "</div>";
            body += "</nav>";
            body += "<div class='container'>";
            body += sections();
            body += "</div>";
            body += "<script src='scripts/slickcustom.js'></script>";
            body += "</body>";
            return body;

        }

        private string sections()
        {
            FileDownload filedownload = new FileDownload();
            string sections = "";
            foreach(var date in dates)
            {
                sections += "<div class='panel panel-default'>";
                sections += String.Format("<div class='panel-heading'>{0}</div>", date);
                sections += "<div class='panel-body'>";
                sections += "<div class='center slider'>";
                var photodates = from photo in photos where photo.earthdate == date select photo;
                foreach(var img in photodates)
                {
                    sections += "<div>";
                    sections += String.Format("<img src='{0}/{1}'/>", Constant.ImageFolder, filedownload.getFileName(img.img_src));
                    sections += "</div>";
                }
                sections += "</div>";
                sections += "</div>";
                sections += "</div>";
            }
            return sections;
        }

        private void OpenHTML(string html)
        {
            Console.WriteLine("Opening the file..");
            File.WriteAllText(htmlFile, html);
            System.Diagnostics.Process.Start(String.Format(htmlFile));
            Console.WriteLine("HTML File was opened.");
        }

        private  String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmssffff");
        }
    }
}
