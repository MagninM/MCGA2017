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
    public class CategoryProcess : ProcessComponent
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Category> SelectList()
        {
            var response = HttpGet<AllCategoryResponse>("rest/Category/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        public Category Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindCategoryResponse>("rest/Category/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public void Insert(Category CAT)
        {
            HttpPost<Category>("rest/Category/Add", CAT, MediaType.Json);            
        }

        public void Edit(Category CAT)
        {
            HttpPost<Category>("rest/Category/Edit", CAT, MediaType.Json);
        }

        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            HttpGet<FindCategoryResponse>("rest/Category/Remove", parameters, MediaType.Json);
        }
    }
}