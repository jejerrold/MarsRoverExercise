using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaAPIProject.common
{
    class MarsRoverHtml
    {
        List<Photos> photos = new List<Photos>();

        public MarsRoverHtml(List<Photos> loadphotos)
        {
            photos = loadphotos;
        }

        public void CreateMarsRoverWebPage()
        {
            string Html = Header();
            Html += Body();
        }

        private string Header()
        {
            string header = "<html lang='en' xmlns='http://www.w3.org/1999/xhtml'>";
            header += "<head>";
            header += "<meta charset='utf-8' />";
            header += "<title></title>";
            header += "<script src='scripts/bootstrap.min.js'></script>";
            header += "<script src='scripts/jquery.js'></script>";
            header += "<link href='styles/bootstrap.min.css' rel='stylesheet' />";
            header += "</head>";
            return header;
        }

        private string Body()
        {
            string body = "<nav class='navbar navbar-default'>";
            body += "<div class='container-fluid'>";
            body += "<div class='navbar-header'>";
            body += "<a class='navbar-brand' href='#'>";
            body += "Mars Rover Gallery";
            body += "</a>";
            body += "</div>";
            body += "</div>";
            body += "</nav>";


            return body;

        }
    }
}
