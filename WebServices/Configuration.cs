using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Services.Protocols;
using WebServices.InstituteReference;

namespace WebServices
{
    public class Configuration
    {
        public static string ODataServiceUrl()
        {
            string obj = string.Empty;
            obj = ConfigurationManager.AppSettings["ODataServiceUrl"];
            return obj;
        }

        public static SoapHttpClientProtocol getNavService(SoapHttpClientProtocol eVService, string serviceName, string serviceType)
        {
            SoapHttpClientProtocol ws = eVService;
            string wsUrl = ConfigurationManager.AppSettings["WebServiceUrl"];
            if (serviceType.Trim().Length != 0)
                wsUrl += serviceType + "/";
            if (serviceName.Trim().Length != 0)
                wsUrl += serviceName;
            ws.UseDefaultCredentials = false;
            ws.Url = HttpUtility.UrlPathEncode(wsUrl);
            ws.Credentials = ODataServiceUrlCredentials();
            return ws;
        }

        public static NetworkCredential ODataServiceUrlCredentials()
        {
            NetworkCredential obj = new NetworkCredential();
            obj.UserName = "SOMNATH";
            obj.Password = "Aug@1817";
            return obj;
        }

        internal static InstituteBuildingCard getNavService(InstituteBuildingCard instituteBuildingCard, string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }
}
