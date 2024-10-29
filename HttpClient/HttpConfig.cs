using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WenawoMessenger.Client.HttpClient
{
    public class HttpConfig
    {
        public string AuthorizationLink { get; set; } = null!;
        public string AuthenteficationLink { get; set; } = null!;
        public string AuthenteficationHub { get; set; } = null!;

        public HttpConfig() { }

        public HttpConfig(HttpConfig httpConfig)
        {
            AuthenteficationHub = httpConfig.AuthenteficationHub;
            AuthenteficationLink = httpConfig.AuthenteficationLink;
            AuthorizationLink = httpConfig.AuthorizationLink;
        }
    }
}
