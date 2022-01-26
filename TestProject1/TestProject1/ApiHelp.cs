using OpenQA.Selenium;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public static class ApiHelp
    {
        public static IRestResponse SendJsonApiRequest(object body, Dictionary<string,string> headers, string link, Method type)
        {
            RestClient client = new RestClient(link)
            {
                Timeout = 300000
            };
         

            RestRequest request = new RestRequest(type);
            foreach(var header in headers)
            {
                request.AddHeader(header.Key, header.Value);
            }

            if(!headers.Any(h => h.Value.Contains("application/json")))
                foreach (var data in (Dictionary<string,string>)body)
                {
                    request.AddParameter(data.Key, data.Value);
                }
            else
            {
                request.AddJsonBody(body);
                request.RequestFormat = DataFormat.Json;
            }
            //request.AddHeader("content-type", "application/json");
            //var body = new Dictionary<string, string>
            //{
            //    {"","" },
            //    {"","" }
            //};

            IRestResponse response = client.Execute(request);
            return response;

        }

        public static Cookie ExtractCookie(IRestResponse response, string cookieName)
        {
            Cookie res = null;
            foreach(var cookie in response.Cookies)
                if (cookie.Name.Equals(cookieName))        
                    res = new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, null);

            return res;
        }

        public static List<Cookie> EXtractAllCookies(IRestResponse response)
        {
            List<Cookie> res = new List<Cookie>();
            foreach (var cookie in response.Cookies)
            {
                res.Add(new Cookie(cookie.Name, cookie.Value, cookie.Domain, cookie.Path, null));
            }
            return res;
        }
    }
}
