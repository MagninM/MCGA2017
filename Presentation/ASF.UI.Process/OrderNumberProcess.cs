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
    public class OrderNumberProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> SelectList()
        {
            var response = HttpGet<AllOrderNumberResponse>("rest/OrderNumber/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrderNumber Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindOrderNumberResponse>("rest/OrderNumber/Find", parameters, MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(OrderNumber orderNumber)
        {
            var response = HttpPost<OrderNumber>("rest/OrderNumber/Add", orderNumber, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            HttpGet<FindOrderNumberResponse>("rest/OrderNumber/Remove", parameters, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(OrderNumber orderNumber)
        {
            var response = HttpPost<OrderNumber>("rest/OrderNumber/Edit", orderNumber, MediaType.Json);
        }

    }
}
