using HellowWorldAPI.DataAccessLayer;
using HellowWorldAPI.Logger;
using HellowWorldAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;

namespace HellowWorldAPI.Controllers
{
    /// <summary>
    /// Hello World Controller
    /// </summary>
    /// <returns></returns>
    public class HelloWorldController : ApiController
    {
       // IRetrieveResults retrieveJsonResult;
        //public HelloWorldController(IRetrieveResults _retrieveJsonResult)
        //{
        //    retrieveJsonResult = _retrieveJsonResult;
        //}
        [System.Web.Http.HttpGet]
        public HttpResponseMessage Index(/*IRetrieveResults _retrieveJsonResult -- can be injected via method also.*/)
        {
            ApplicationFileLogger _exceptionLogger = new ApplicationFileLogger();
            IRetrieveResults retrieveJsonResult = new TextDataDAL(_exceptionLogger);
            List<TextData> textDataResult = retrieveJsonResult.LoadTextResults();
            //convert to back to JSON.This is actually JSOn file to start with but just to show the flow of the data, i am serializing and deserializing the same JSON.
            return new HttpResponseMessage
            {
                Content = new StringContent(JsonConvert.SerializeObject(textDataResult),
                                            System.Text.Encoding.UTF8, "application/json")
            };
        }
    }
}
