using SimpleLoggingService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace LogInfoCaller
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Uri for Simple Logging Service: ");
            var SLSUri = Console.ReadLine();
            if (!SLSUri.ToLower().EndsWith("/api/simplelog"))
            {
                SLSUri = SLSUri.EndsWith("/") ? SLSUri + "api/simplelog" : SLSUri + "/api/simplelog";
            }
            var LogToUse = new LogInfo() { AppName = "LogInfoCaller", TimeStamp = DateTime.Now, Severity = "Notice", LogMessage = "Testing Logging Service" };

            Console.WriteLine($"Posting example log to logging service at : {SLSUri}");
            string jsonData = JsonConvert.SerializeObject(LogToUse);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            try
            {
                var result = client.PostAsync(SLSUri, content).Result;
                if (result.IsSuccessStatusCode)
                {
                    Console.WriteLine("Post succeeded");
                }
                else
                {
                    Console.WriteLine($"Post failed. Service is not running at {SLSUri}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Post failed. Service is not running at {SLSUri}");
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true); 
        }
    }
}
