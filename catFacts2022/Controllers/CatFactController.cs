using catFacts2022.Class;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CatFacts.Controllers
{
    public class CatFactController : ValuesController
    {
        [System.Web.Http.HttpGet, OutputCache(Duration = 5, Location = OutputCacheLocation.Any, VaryByParam = "none")]
        public HttpResponseMessage getRandomFact(int? max_length = null)
        {
            List<CatFactsList> randomCatFactsList = new List<CatFactsList>();
            List<CatFactsList> randomCatFactsListResult = new List<CatFactsList>();
            CatFactsList randomCatFactsResult = new CatFactsList();
            randomCatFactsList = GetCatFactData(); //get cat facts data from local path


            if (randomCatFactsList != null)
            {
                try
                {
                    if (max_length == null)
                    {
                        Random random = new Random();
                        int randomNumber = random.Next(0, randomCatFactsList.Count); // get random number
                        randomCatFactsResult = randomCatFactsList[randomNumber];
                        randomCatFactsListResult.Add(new CatFactsList { fact = randomCatFactsResult.fact, length = randomCatFactsResult.length }); // Add random element to the result
                    }
                    else
                    {
                        randomCatFactsListResult = randomCatFactsList.Where(x => int.Parse(x.length) == max_length).ToList(); //select target element in the cat facts list
                        if (randomCatFactsListResult == null)
                        {
                            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Fact not found");
                        }
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Fact not found");
                }
            }
            else
            {

                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Fact not found");
            }

            return Request.CreateResponse<List<CatFactsList>>(HttpStatusCode.OK, randomCatFactsListResult);
        }
        [System.Web.Http.HttpGet, OutputCache(Duration = 5, Location = OutputCacheLocation.Any, VaryByParam = "none")]
        public HttpResponseMessage getFacts(int? max_length = null, int? limit = null)
        {

            List<CatFactsList> CatFactsFullList = new List<CatFactsList>();
            List<CatFactsList> CatFactsFullListResult = new List<CatFactsList>();
            CatFactsFullList = GetCatFactData(); //get cat facts data from local path


            if (CatFactsFullList != null)
            {
                try
                {
                    if (max_length != null)
                    {
                        if (limit == null)
                        {
                            CatFactsFullListResult = CatFactsFullList.Where(x => int.Parse(x.length) <= max_length).ToList(); //select target element in the cat facts list
                        }
                        else
                        {
                            int limitRecord = limit == null ? 0 : limit.Value;
                            CatFactsFullListResult = CatFactsFullList.Where(x => int.Parse(x.length) <= max_length).Take(limitRecord).ToList(); //select limit target element in the cat facts list
                        }
                    }
                    else
                    {
                        return Request.CreateResponse<List<CatFactsList>>(HttpStatusCode.OK, CatFactsFullList); // return full list when max_length is null
                    }
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Fact not found"); // return not found 
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Fact not found"); // return not found 
            }

            return Request.CreateResponse<List<CatFactsList>>(HttpStatusCode.OK, CatFactsFullListResult);
        }
        [System.Web.Http.HttpPost, OutputCache(Duration = 5, Location = OutputCacheLocation.Any, VaryByParam = "none")]
        public HttpResponseMessage addNewFact([System.Web.Http.FromBody]dynamic value)
        {

            CatFactsList NewFactitems = new CatFactsList();
            if (value == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request. Invalid fact.");
            }

            string newFact = value.fact;
            string newLength = value.length;

            NewFactitems.fact = newFact;
            NewFactitems.length = newLength;

            Facts FactsList = new Facts();
            List<CatFactsList> CatFactsFullList = new List<CatFactsList>();
            CatFactsFullList = GetCatFactData(); //get cat facts data from local path
            if (CatFactsFullList != null)
            {
                try
                {
                    CatFactsFullList.Add(new CatFactsList { fact = newFact, length = newLength }); //Add new items to List


                    FactsList.facts = CatFactsFullList;

                    string newCatFactList = JsonConvert.SerializeObject(FactsList);// Generate JSON based after added the new items
                    string dataFilePath = System.Configuration.ConfigurationManager.AppSettings["DataFilePath"].ToString().Trim(); //get json file path
                    System.IO.File.WriteAllText(dataFilePath, newCatFactList); // Write that to cat facts json file
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request. Invalid fact.");
                }
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad request. Invalid fact.");
            }

            return Request.CreateResponse<CatFactsList>(HttpStatusCode.Created, NewFactitems);
        }
    }
}