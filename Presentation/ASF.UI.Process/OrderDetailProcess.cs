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
    public class OrderDetailProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<OrderDetail> SelectList()
        {
            var response = HttpGet<AllOrderDetailResponse>("rest/OrderDetail/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public OrderDetail Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindOrderDetailResponse>("rest/OrderDetail/Find", parameters, MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(OrderDetail orderDetail)
        {
            var response = HttpPost<OrderDetail>("rest/OrderDetail/Add", orderDetail, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            HttpGet<FindOrderDetailResponse>("rest/OrderDetail/Remove", parameters, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(OrderDetail orderDetail)
        {
            var response = HttpPost<OrderDetail>("rest/OrderDetail/Edit", orderDetail, MediaType.Json);
        }

        public List<OrderDetail> FindeByOrderId(int on)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("on", on);
            var response = HttpGet<AllOrderDetailResponse>("rest/OrderDetail/FindByOrderId", parameters, MediaType.Json);
            return response.Result;
        }
    }
}
