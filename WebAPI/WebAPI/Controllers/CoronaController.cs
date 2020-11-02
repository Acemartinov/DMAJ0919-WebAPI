using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    public class CoronaController : ApiController
    {
        // GET: api/Corona
        public List<Datum> Get()
        {
            CoronaOperations coop = new CoronaOperations();
            return coop.GetTheRecords("SELECT * FROM theStats");
        }

        // GET: api/Corona
        public List<Datum> Get(string country)
        {
            CoronaOperations coop = new CoronaOperations();
            return coop.GetTheRecords(string.Format("SELECT * FROM theStats WHERE countrycode = '{0}'", country));
        }

        // GET: api/Corona/5
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Corona
        public HttpResponseMessage Post([FromBody]Datum newEntry)
        {
            CoronaOperations coop = new CoronaOperations();
            int x = coop.InsertRecord(string.Format("INSERT INTO theStats(countrycode, date, cases, deaths, recovered) VALUES('{0}','{1}','{2}','{3}','{4}')", newEntry.countrycode, newEntry.date, newEntry.cases, newEntry.deaths, newEntry.recovered));
            if (x == 1)
            {
                return new HttpResponseMessage(HttpStatusCode.OK);
            } else
            {
                return new HttpResponseMessage(HttpStatusCode.Conflict);
            }
            
        }

        // PUT: api/Corona/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Corona/5
        public void Delete(int id)
        {
        }
    }
}
