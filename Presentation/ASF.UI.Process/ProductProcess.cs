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
    public class ProductProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Product> SelectList()
        {
            var response = HttpGet<AllProductResponse>("rest/Product/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public List<Product> SelectByCat(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<AllProductResponse>("rest/Product/SelectByCat", parameters, MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Product Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindProductResponse>("rest/Product/Find", parameters, MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Product prd)
        {
            var response = HttpPost<Product>("rest/Product/Add", prd, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            HttpGet<FindProductResponse>("rest/Product/Remove", parameters, MediaType.Json); ;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Product prd)
        {
            var response = HttpPost<Product>("rest/Product/Edit", prd, MediaType.Json);
        }

    }
}
