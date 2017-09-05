﻿using System;
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
            var response = HttpGet<FindResponse>("rest/Category/Find", parameters, MediaType.Json);
            return response.Result;
        }

        //public List<Category> Find(int I)
        //{
        //    var parameters = new Dictionary<string, object>();
        //    var response = HttpGet<AllResponse>("rest/Category/Find", new Dictionary<string, object>(I), MediaType.Json);
        //    return response.Result;
        //}
    }
}