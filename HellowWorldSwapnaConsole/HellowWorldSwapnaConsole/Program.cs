using HellowWorldAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;

namespace SwapnaHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //call web service to retrieve the hellow world from the JSOn which is in web API solution.
            using (var client = new WebClient()) //WebClient  
            {
                client.Headers.Add("Content-Type:application/json"); //Content-Type  
                client.Headers.Add("Accept:application/json");
                var result = client.DownloadString("http://localhost:56629/api/helloworld"); //URI  
                List<TextData> textDataString = (new JavaScriptSerializer()).Deserialize<List<TextData>>(result);
                if (textDataString.Count > 0)
                {
                    foreach (TextData textDataStringSingle in textDataString)
                    {
                        Console.WriteLine(Environment.NewLine + textDataStringSingle.Text);
                    }
                }
                else
                {
                    Console.WriteLine("No records found.");
                }
            }

            //stop console from closing
            Console.ReadLine();
        }
    }
}
