using System;
using System.IO;

namespace LawyerList
{
    /// <summary>
    ///
    /// </summary>
    internal class Program
    {
        private static string[] _Categories = { "Advocacy", "Business Law", "Children's Law", "Commercial Litigation",
                                    "Criminal Law", "Dispute Resolution", "Employment & Industrial Law", "Family Law",
                                    "Government & Administrative Law", "Immigration Law", "Local Government & Planning Law",
                                    "Mediation", "Personal Injury", "Planning & Environment", "Property Law", "Taxation Law", "Wills & Estates Law" };

        private static void Main(string[] args)
        {
            Console.WriteLine("");

            var url = @"https://az-ae-app-fal-prod-webservice.azurewebsites.net/api/lawyer";

            // json example: "{\"lastName\":\"\",\"otherName\":\"\",\"suburb\":\"\",\"region\":\"\",\"accreditedSpecialist\":\"Business Law\",\"page\":1,\"pageSize\":200}"

            foreach (var item in _Categories)
            {
                var json = "{\"lastName\":\"\",\"otherName\":\"\",\"suburb\":\"\",\"region\":\"\",\"accreditedSpecialist\":\"" + item + "\",\"page\":1,\"pageSize\":2000}";
                Console.WriteLine(item);
                Console.WriteLine(json);

                var resultJson = Network.SendJsonRequest(url, json);

                // Save JSON
                var filenameJson = string.Format("result_{0}_{1}.json", item, DateTime.Now.Ticks);
                File.WriteAllText(filenameJson, resultJson);

                // SAve as XML
                var resultXml = DataFormatHelper.JsonToXml(resultJson);
                var filenameXml = string.Format("result_{0}_{1}.xml", item, DateTime.Now.Ticks);
                resultXml.Save(filenameXml);
            }
        }
    }
}