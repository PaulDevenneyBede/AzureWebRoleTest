using System.Configuration;
using Bede.Middleware.Clients.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MvcWebRole1.App_Start
{
    public class ConfigCommonServiceSettings : ICommonServiceSettings
    {
        public string ApplicationKey
        {
            get { return ConfigurationManager.AppSettings["ApplicationKey"]; }
        }

        public string HostUrl
        {
            get { return ConfigurationManager.AppSettings["HostUrl"]; }
        }
    }
}
