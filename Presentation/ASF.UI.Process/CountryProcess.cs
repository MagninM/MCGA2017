using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.UI.Process;

namespace ASF.UI.Process
{
    public class CountryProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Country> SelectList()
        {
            var response = HttpGet<AllResponseCountry>("rest/Country/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Country Find(int id)
        {
            var path = "rest/Country/Find/" + id;
            var response = HttpGet<FindResponseCountry>(path, new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Country pais)
        {
            var response = HttpPost<Country>("rest/Country/Add", pais, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var path = "rest/Country/Remove/" + id;
            var response = HttpGet<FindResponseCountry>(path, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Country pais)
        {
            var response = HttpPost<Country>("rest/Country/Edit", pais, MediaType.Json);
        }
    }
}
