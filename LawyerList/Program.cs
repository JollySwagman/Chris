using System;
using System.IO;

namespace LawyerList
{
    internal class Program
    {
        private string[] _Categories = { "Advocacy", "Business Law", "Children's Law", "Commercial Litigation",
                                    "Criminal Law", "Dispute Resolution", "Employment & Industrial Law", "Family Law",
                                    "Government & Administrative Law", "Immigration Law", "Local Government & Planning Law",
                                    "Mediation", "Personal Injury", "Planning & Environment", "Property Law", "Taxation Law", "Wills & Estates Law" };

        private static void Main(string[] args)
        {
            Console.WriteLine("");

            var url = @"https://az-ae-app-fal-prod-webservice.azurewebsites.net/api/lawyer";
            var json = "{\"lastName\":\"\",\"otherName\":\"\",\"suburb\":\"\",\"region\":\"\",\"accreditedSpecialist\":\"Business Law\",\"page\":1,\"pageSize\":200}";

            //var resultJson = Network.SendJsonMessage(url, json);

            var resultJson = File.ReadAllText("result_636585365893435289.json");

            //var filenameJson = string.Format("result_{0}.json", DateTime.Now.Ticks);
            //File.WriteAllText(filenameJson, resultJson);

            var resultXml = DataFormatHelper.JsonToXml(resultJson);
            var filenameXml = string.Format("result_{0}.xml", DateTime.Now.Ticks);
            resultXml.Save(filenameXml);
        }
    }
}