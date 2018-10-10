/// <summary>
/// fetch the data from database(JSON) and load it to the business Model which is TextData.For retrieving results from SQl, we need to write another DAL class and work with ADO.NET for example.
/// </summary>
using HellowWorldAPI.Interfaces;
using HellowWorldAPI.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Script.Serialization;

namespace HellowWorldAPI.DataAccessLayer
{
    public class TextDataDAL : IRetrieveResults
    {
        ILogger exceptionLogger;
        public TextDataDAL(ILogger _exceptionLogger)
        {
            exceptionLogger = _exceptionLogger;
        }
       public List<TextData> LoadTextResults()
       {
            List<TextData> textDataResultsFromDB = new List<TextData>();
            try
            {
                //get the Json filepath from the app configuration file. 
                string fileToRead = System.Web.Hosting.HostingEnvironment.MapPath(ConfigurationManager.AppSettings["ConnectionString"]);
                //deserialize JSON from file  
                string outputJson = System.IO.File.ReadAllText(fileToRead);
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                //deserialize the Text data
                textDataResultsFromDB = serializer.Deserialize<List<TextData>>(outputJson);
            }
            catch (System.Exception ex)
            {
                //this will log the error to file currently as it is configured to log to file in the startup.cs
                exceptionLogger.Error(ex.StackTrace);
            }
            return textDataResultsFromDB;
        }
    }
}
