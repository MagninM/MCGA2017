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
    public class OrderNumberProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderNumber> SelectList()
        {
            var response = HttpGet<AllResponseOrderNumber>("rest/OrderNumber/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrderNumber Find(int id)
        {
            var path = "rest/OrderNumber/Find/" + id;
            var response = HttpGet<FindResponseOrderNumber>(path, new Dictionary<string, object>(), MediaType.Json);
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
            var path = "rest/OrderNumber/Remove/" + id;
            var response = HttpGet<FindResponseOrderNumber>(path, new Dictionary<string, object>(), MediaType.Json);
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
