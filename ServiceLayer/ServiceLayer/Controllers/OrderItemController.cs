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
    public class OrderItemController : ApiController
    {
        private readonly IOrderItem _OrderItemLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public OrderItemController(IOrderItem OrderItemLogic, IMapper mapper)
        {
            _OrderItemLogic = OrderItemLogic;
            _mapper = mapper;
        }



        // GET: api/OrderItem/5

        //[Route("~/api/OrderItems/ID")]
        [HttpGet]
        [ResponseType(typeof(Models.OrderItemServiceModel))]
        public IHttpActionResult GetOrderItem(int ID)
        {
            List<OrderItem> OdrI;
            try
            {
                OdrI = _OrderItemLogic.GetOrderItemsByID(ID);
            }
            catch
            {
                return InternalServerError();
            }
            if (OdrI == null)
            {
                return NotFound();
            }

            var OdrI_SL = _mapper.Map<Models.OrderItemServiceModel>(OdrI);
            return Ok(OdrI_SL);
        }

        public IHttpActionResult GetOrderItems()
        {
            try
            {
                var OrderItem = _mapper.Map<IEnumerable<OrderItemServiceModel>>(_OrderItemLogic.AllOdrI());
                return Ok(OrderItem);
            }
            catch
            {
                return InternalServerError();
            }
        }
        // PUT: api/OrderItem/5
        [ResponseType(typeof(Models.OrderItemServiceModel))]
        [HttpPut]
        public IHttpActionResult PutOrderItem(Models.OrderItemServiceModel OdrI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //OdrI.Email = email;

            List<OrderItem> test;
            try
            {
                test = _OrderItemLogic.GetOrderItemsByID(OdrI.orderID);
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            if (test == null)
            {
                return NotFound();
            }

            var OdrI_DAL = _mapper.Map<OrderItem>(OdrI);
            try
            {
                _OrderItemLogic.UpdateOdrI(OdrI_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                OdrI_DAL = null;
                OdrI_DAL = _mapper.Map<OrderItem>(OdrI);
                if (OdrI_DAL == null)
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

            var OdrI_SL = _mapper.Map<Models.OrderItemServiceModel>(OdrI_DAL);
            return Ok(OdrI_SL);
        }

        // POST: api/OrderItems
        [ResponseType(typeof(Models.OrderItemServiceModel))]
        public IHttpActionResult PostOrderItem(Models.OrderItemServiceModel OdrI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var OdrILogic = _mapper.Map<OrderItem>(OdrI);

            try
            {
                _OrderItemLogic.AddOdrI(OdrILogic);
            }
            catch
            {
                return InternalServerError();
            }

            var newOrderItem = _mapper.Map<Models.OrderItemServiceModel>(OdrILogic);
            return CreatedAtRoute("DefaultApi", new { email = OdrI.orderID }, newOrderItem);
        }

        // DELETE: api/OrderItems/5
        [ResponseType(typeof(Models.OrderItemServiceModel))]
        public IHttpActionResult DeleteOrderItem(int ID)
        {
            List<OrderItem> OdrI_DAL;
            try
            {
                OdrI_DAL = _OrderItemLogic.GetOrderItemsByID(ID);
                //OdrI_DAL = _mapper.Map<OrderItem>(OdrI);
            }
            catch
            {
                return InternalServerError();
            }
            if (OdrI_DAL == null)
            {
                return NotFound();
            }

            try
            {
                _OrderItemLogic.DeleteOdrI(OdrI_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var OdrI_SL = _mapper.Map<Models.OrderItemServiceModel>(OdrI_DAL);
            return Ok(OdrI_SL);
        }

    }
}