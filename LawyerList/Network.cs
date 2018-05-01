using System;
using System.IO;
using System.Net;

namespace LawyerList
{
    public class Network
    {
        public static string GetHtml(string url)
        {
            return null;
        }

        public static string SendJsonRequest(string url, string json)
        {
            string responseText = null;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
            }

            return responseText;
        }
    }
}