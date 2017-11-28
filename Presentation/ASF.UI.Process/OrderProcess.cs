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
using ASF.Services.Contracts.Responses;

namespace ASF.UI.Process
{
    public class OrderProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Order> SelectList()
        {
            var response = HttpGet<AllOrderResponse>("rest/Order/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Order Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindOrderResponse>("rest/Order/Find", parameters, MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Order Insert(Order order)
        {
            var response = HttpPost<Order>("rest/Order/Add", order, MediaType.Json);
            return response;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            HttpGet<FindOrderResponse>("rest/Order/Remove", parameters, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Order order)
        {
            var response = HttpPost<Order>("rest/Order/Edit", order, MediaType.Json);
        }

        public Order FindByOrderNumber(int order)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("order", order);
            var response = HttpGet<FindOrderResponse>("rest/Order/FindByOrder", parameters, MediaType.Json);
            return response.Result;
        }
    }
}
