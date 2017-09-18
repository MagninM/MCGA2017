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
    public class RatingProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Rating> SelectList()
        {
            var response = HttpGet<AllResponseRating>("rest/Rating/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Rating Find(int id)
        {
            var path = "rest/Rating/Find/" + id;
            var response = HttpGet<FindResponseRating>(path, new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Rating rtng)
        {
            var response = HttpPost<Rating>("rest/Rating/Add", rtng, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var path = "rest/Rating/Remove/" + id;
            var response = HttpGet<FindResponseRating>(path, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Rating rtng)
        {
            var response = HttpPost<Rating>("rest/Rating/Edit", rtng, MediaType.Json);
        }

    }
}
