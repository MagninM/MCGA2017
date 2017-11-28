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
    public class ClientProcess : ProcessComponent
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Client> SelectList()
        {
            var response = HttpGet<AllClientResponse>("rest/Client/All", new Dictionary<string, object>(), MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Client Find(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            var response = HttpGet<FindClientResponse>("rest/Client/Find", parameters, MediaType.Json);
            return response.Result;
        }

        public Client FindByASPUSER(string aspuser)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("aspuser", aspuser);
            var response = HttpGet<FindClientResponse>("rest/Client/FindByASPUSER", parameters, MediaType.Json);
            return response.Result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Insert(Client client)
        {
            var response = HttpPost<Client>("rest/Client/Add", client, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Delete(int id)
        {
            var parameters = new Dictionary<string, object>();
            parameters.Add("id", id);
            HttpGet<FindClientResponse>("rest/Client/Remove", parameters, MediaType.Json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void Edit(Client client)
        {
            var response = HttpPost<Client>("rest/Client/Edit", client, MediaType.Json);
        }

    }
}
