﻿//====================================================================================================
// Base code generated with LeatherGoods - ASF.Services.Http
// Architecture Solutions Foundation
//
// Generated by academic at LeatherGoods V 1.0 
//====================================================================================================

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ASF.Business;
using ASF.Entities;
using ASF.Services.Contracts;
using ASF.Services.Contracts.Responses;

namespace ASF.Services.Http
{
    /// <summary>
    /// Setting HTTP service controller.
    /// </summary>
    [RoutePrefix("rest/Setting")]
    public class SettingService : ApiController
    {

        [HttpPost]
        [Route("Add")]
        public Setting Add(Setting setting)
        {
            try
            {
                var bs = new SettingBusiness();
                return bs.Add(setting);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("All")]
        public AllSettingResponse All()
        {
            try
            {
                var response = new AllSettingResponse();
                var bs = new SettingBusiness();
                response.Result = bs.All();
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpPost]
        [Route("Edit")]
        public void Edit(Setting setting)
        {
            try
            {
                var bs = new SettingBusiness();
                setting.ChangedOn = System.DateTime.Now;
                setting.LastChangeDate = System.DateTime.Now;
                bs.Edit(setting);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("Find")]
        public FindSettingResponse Find(int id)
        {
            try
            {
                var response = new FindSettingResponse();
                var bs = new SettingBusiness();
                response.Result = bs.Find(id);
                return response;
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

        [HttpGet]
        [Route("Remove")]
        public void Remove(int id)
        {
            try
            {
                var bs = new SettingBusiness();
                bs.Remove(id);
            }
            catch (Exception ex)
            {
                var httpError = new HttpResponseMessage()
                {
                    StatusCode = (HttpStatusCode)422,
                    ReasonPhrase = ex.Message
                };

                throw new HttpResponseException(httpError);
            }
        }

    }
}
