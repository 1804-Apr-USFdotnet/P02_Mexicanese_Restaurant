using AutoMapper;
using AutoMapper.QueryableExtensions;
using NLog;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogicLayer;
using DataAccessLayer.Models;
using System.Web.Http.Description;
using ServiceLayer.Models;

namespace ServiceLayer.Controllers
{
    public class OrderCouponController : ApiController
    {
        private readonly IOrderCoupon _OrderCouponLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public OrderCouponController(IOrderCoupon OrderCouponLogic, IMapper mapper)
        {
            _OrderCouponLogic = OrderCouponLogic;
            _mapper = mapper;
        }



        // GET: api/OrderCoupon/5

        //[Route("~/api/OrderCoupons/ID")]
        [HttpGet]
        [ResponseType(typeof(Models.OrderCouponServiceModel))]
        public IHttpActionResult GetOrderCoupon(int ID)
        {
            OrderCoupon OC;
            try
            {
                OC = _OrderCouponLogic.GetOrderCouponByID(ID);
            }
            catch
            {
                return InternalServerError();
            }
            if (OC == null)
            {
                return NotFound();
            }

            var OC_SL = _mapper.Map<Models.OrderCouponServiceModel>(OC);
            return Ok(OC_SL);
        }

        public IHttpActionResult GetOrderCoupons()
        {
            try
            {
                var OrderCoupon = _mapper.Map<IEnumerable<OrderCouponServiceModel>>(_OrderCouponLogic.AllOC());
                return Ok(OrderCoupon);
            }
            catch
            {
                return InternalServerError();
            }
        }
        // PUT: api/OrderCoupon/5
        [ResponseType(typeof(Models.OrderCouponServiceModel))]
        [HttpPut]
        public IHttpActionResult PutOrderCoupon(Models.OrderCouponServiceModel OC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            

            OrderCoupon test;
            try
            {
                test = _OrderCouponLogic.GetOrderCouponByID(OC.orderID);
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            if (test == null)
            {
                return NotFound();
            }

            var OC_DAL = _mapper.Map<OrderCoupon>(OC);
            try
            {
                _OrderCouponLogic.UpdateOC(OC_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                OC_DAL = null;
                OC_DAL = _mapper.Map<OrderCoupon>(OC);
                if (OC_DAL == null)
                {
                    return NotFound();
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch
            {
                return InternalServerError();
            }

            var OC_SL = _mapper.Map<Models.OrderCouponServiceModel>(OC_DAL);
            return Ok(OC_SL);
        }

        // POST: api/OrderCoupons
        [ResponseType(typeof(Models.OrderCouponServiceModel))]
        public IHttpActionResult PostOrderCoupon(Models.OrderCouponServiceModel OC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var OCLogic = _mapper.Map<OrderCoupon>(OC);

            try
            {
                _OrderCouponLogic.AddOC(OCLogic);
            }
            catch
            {
                return InternalServerError();
            }

            var newOrderCoupon = _mapper.Map<Models.OrderCouponServiceModel>(OCLogic);
            return CreatedAtRoute("DefaultApi", new { orderID = OC.orderID }, newOrderCoupon);
        }

        // DELETE: api/OrderCoupons/5
        [ResponseType(typeof(Models.OrderCouponServiceModel))]
        public IHttpActionResult DeleteOrderCoupon(int ID)
        {
            OrderCoupon OC_DAL;
            try
            {
                OC_DAL = _OrderCouponLogic.GetOrderCouponByID(ID);
                //OC_DAL = _mapper.Map<OrderCoupon>(OC);
            }
            catch
            {
                return InternalServerError();
            }
            if (OC_DAL == null)
            {
                return NotFound();
            }

            try
            {
                _OrderCouponLogic.DeleteOC(OC_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var OC_SL = _mapper.Map<Models.OrderCouponServiceModel>(OC_DAL);
            return Ok(OC_SL);
        }

    }
}