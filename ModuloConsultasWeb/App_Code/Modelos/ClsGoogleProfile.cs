using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModuloConsultasWeb.App_Code.Modelos
{
    public class ClsGoogleProfile
    {
        string prueba;

        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Image Image { get; set; }
        public List<Email> Emails { get; set; }
        public string Gender { get; set; }
        public string ObjectType { get; set; }
        public string Domain { get; set; }

    }

    public class Email
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }

    public class Image
    {
        public string Url { get; set; }
    }


}