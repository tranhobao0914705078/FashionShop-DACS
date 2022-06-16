using AutoMapper;
using FashionShop.Model.Models;
using FashionShop.Service;
using FashionShop.Web.Infrastructure.Core;
using FashionShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FashionShop.Web.Api
{
    [RoutePrefix("api/orderdetail")]
    public class OrderDetailController : ApiControllerBase
    {
        IOrderDetailService _orderDetailService;
        public OrderDetailController(IErrorService errorService, IOrderDetailService orderDetailService) : base(errorService)
        {
            this._orderDetailService = orderDetailService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _orderDetailService.GetAll();
                var responseData = Mapper.Map<IEnumerable<OrderDetails>, IEnumerable<OrderDetailViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }

}
