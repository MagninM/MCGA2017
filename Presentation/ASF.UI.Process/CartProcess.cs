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
    public class CartProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Cart> SelectList()
        {
            var response = HttpGet<AllResponseCart>("rest/Cart/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Cart Find(int id)
        {
            var path = "rest/Cart/Find/" + id;
            var response = HttpGet<FindResponseCart>(path, new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Cart cart)
        {
            var response = HttpPost<Cart>("rest/Cart/Add", cart, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var path = "rest/Cart/Remove/" + id;
            var response = HttpGet<FindResponseCart>(path, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Cart cart)
        {
            var response = HttpPost<Cart>("rest/Cart/Edit", cart, MediaType.Json);
        }

    }
}
