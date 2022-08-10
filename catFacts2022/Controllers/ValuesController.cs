using catFacts2022.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatFacts.Controllers
{
    public class ValuesController : ApiController
    {
        // POST api/values
        public List<CatFactsList> GetCatFactData()
        {
            List<CatFactsList> catFactsList = new List<CatFactsList>();
            string dataFilePath = System.Configuration.ConfigurationManager.AppSettings["DataFilePath"].ToString().Trim(); //get json file path
            try
            {
                string readData = System.IO.File.ReadAllText(dataFilePath); // read json file
                if (string.IsNullOrWhiteSpace(readData)) return null;//return null when there is no file path

                dynamic jsonContent = JsonConvert.DeserializeObject(readData);
                catFactsList = JsonConvert.DeserializeObject<List<CatFactsList>>(jsonContent.facts.ToString());
                if (catFactsList == null || catFactsList.Count == 0) return null; //return null when there is no record
            }
            catch (Exception ex)
            {
                return null;
            }

            return catFactsList;
        }


    }
}
