using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace LawyerList
{
    public class Network
    {

        public static string GetHtml(string url)
        {
            return null;
        }


        public static string SendJsonMessage(string url, string json)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "text/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string json = "{ \"method\": \"send\", " +
                //                  "  \"params\": [ " +
                //                  "             \"IPutAGuidHere\", " +
                //                  "             \"msg@MyCompany.com\", " +
                //                  "             \"MyTenDigitNumberWasHere\", " +
                //                  "             \"" + message + "\" " +
                //                  "             ] " +
                //                  "}";

                streamWriter.Write(json);
            }

            string responseText = null;

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseText = streamReader.ReadToEnd();
                //Now you have your response.
                //or false depending on information in the response
                //return true;
            }

            return responseText;
        }

    }
}
