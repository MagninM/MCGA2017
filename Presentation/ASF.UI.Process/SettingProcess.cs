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
    public class SettingProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Setting> SelectList()
        {
            var response = HttpGet<AllResponseSetting>("rest/Setting/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Setting Find(int id)
        {
            var path = "rest/Setting/Find/" + id;
            var response = HttpGet<FindResponseSetting>(path, new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Setting stng)
        {
            var response = HttpPost<Setting>("rest/Setting/Add", stng, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var path = "rest/Setting/Remove/" + id;
            var response = HttpGet<FindResponseSetting>(path, new Dictionary<string, object>(), MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Setting stng)
        {
            var response = HttpPost<Setting>("rest/Setting/Edit", stng, MediaType.Json);
        }

    }
}
