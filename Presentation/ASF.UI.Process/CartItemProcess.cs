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
    public class CartItemProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItem> SelectList()
        {
            var response = HttpGet<AllCartItemResponse>("rest/CartItem/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public CartItem Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindCartItemResponse>("rest/CartItem/Find", parameters, MediaType.Json);
            return response.Result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CartItem> FindByCartId(int Cid)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("Cid", Cid);
            var response = HttpGet<AllCartItemResponse>("rest/CartItem/FindByCartId", parameters, MediaType.Json);
            return response.Result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(CartItem cartItem)
        {
            var response = HttpPost<CartItem>("rest/CartItem/Add", cartItem, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            HttpGet<FindCartItemResponse>("rest/CartItem/Remove", parameters, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(CartItem cartItem)
        {
            var response = HttpPost<CartItem>("rest/CartItem/Edit", cartItem, MediaType.Json);
        }


    }
}
