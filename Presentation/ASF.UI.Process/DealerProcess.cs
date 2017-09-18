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
    public class DealerProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Dealer> SelectList()
        {
            var response = HttpGet<AllResponseDealer>("rest/Dealer/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dealer Find(int id)
        {
            var path = "rest/Dealer/Find/" + id;
            var response = HttpGet<FindResponseDealer>(path, new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Dealer dealer)
        {
            var response = HttpPost<Dealer>("rest/Dealer/Add", dealer, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var path = "rest/Dealer/Remove/" + id;
            var response = HttpGet<FindResponseDealer>(path, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Dealer dealer)
        {
            var response = HttpPost<Dealer>("rest/Dealer/Edit", dealer, MediaType.Json);
        }

    }
}
