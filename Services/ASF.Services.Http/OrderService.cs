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
    /// Order HTTP service controller.
    /// </summary>
    [RoutePrefix("rest/Order")]
    public class OrderService : ApiController
    {

        [HttpPost]
        [Route("Add")]
        public Order Add(Order order)
        {
            try
            {
                var bo = new OrderBusiness();
                order.OrderDate = System.DateTime.Now;
                return bo.Add(order);
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
        public AllOrderResponse All()
        {
            try
            {
                var response = new AllOrderResponse();
                var bo = new OrderBusiness();
                response.Result = bo.All();
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
        public void Edit(Order order)
        {
            try
            {
                var bo = new OrderBusiness();
                order.ChangedOn = System.DateTime.Now;
                bo.Edit(order);
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
        public FindOrderResponse Find(int id)
        {
            try
            {
                var response = new FindOrderResponse();
                var bo = new OrderBusiness();
                response.Result = bo.Find(id);
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
        [Route("FindByOrder")]
        public FindOrderResponse FindByOrder(int order)
        {
            try
            {
                var response = new FindOrderResponse();
                var bo = new OrderBusiness();
                response.Result = bo.FindByOrder(order);
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
                var bo = new OrderBusiness();
                bo.Remove(id);
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
