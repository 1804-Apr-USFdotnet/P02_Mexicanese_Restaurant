using AutoMapper;
using NLog;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using BusinessLogicLayer;
using DataAccessLayer.Models;
using System.Web.Http.Description;
using ServiceLayer.Models;

namespace ServiceLayer.Controllers
{
    public class OrderController : ApiController
    {
        private readonly IOrder _OrderLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public OrderController(IOrder OrderLogic, IMapper mapper)
        {
            _OrderLogic = OrderLogic;
            _mapper = mapper;
        }

        

        // GET: api/Order/5
       
        //[Route("~/api/Orders/ID")]
        [HttpGet]
        [ResponseType(typeof(Models.OrderServiceModel))]
        public IHttpActionResult GetOrder(int ID)
        {
            OrderItemLogic odriLogic = new OrderItemLogic();
            Order Odr;
            List<OrderItem> items = new List<OrderItem>(); 
            try
            {
                Odr = _OrderLogic.GetOrderByID(ID);
            }
            catch
            {
                return InternalServerError();
            }
            if (Odr == null)
            {
                return NotFound();
            }

            var Odr_SL = _mapper.Map<Models.OrderServiceModel>(Odr);
            items = odriLogic.GetOrderItemsByID(ID);
            foreach (var item in items)
            {
                Odr_SL.OrderItems.Add(item);
            }

            return Ok(Odr_SL);
        }

        public IHttpActionResult GetOrders()
        {
            try
            {
                var Order = _mapper.Map<IEnumerable<OrderServiceModel>>(_OrderLogic.AllOdr());
                return Ok(Order);
            }
            catch
            {
                return InternalServerError();
            }
        }
        // PUT: api/Order/5
        [ResponseType(typeof(Models.OrderServiceModel))]
        [HttpPut]
        public IHttpActionResult PutOrder(Models.OrderServiceModel Odr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Odr.Email = email;

            Order test;
            try
            {
                test = _OrderLogic.GetOrderByID(Odr.OrderID);
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            if (test == null)
            {
                return NotFound();
            }

            var Odr_DAL = _mapper.Map<Order>(Odr);
            try
            {
                _OrderLogic.UpdateOdr(Odr_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                Odr_DAL = null;
                Odr_DAL = _mapper.Map<Order>(Odr);
                if (Odr_DAL == null)
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

            var Odr_SL = _mapper.Map<Models.OrderServiceModel>(Odr_DAL);
            return Ok(Odr_SL);
        }

        // POST: api/Orders
        [ResponseType(typeof(Models.OrderServiceModel))]
        public IHttpActionResult PostOrder(Models.OrderServiceModel Odr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var OdrLogic = _mapper.Map<Order>(Odr);

            try
            {
                _OrderLogic.AddOdr(OdrLogic);
            }
            catch
            {
                return InternalServerError();
            }
            
            var newOrder = _mapper.Map<Models.OrderServiceModel>(OdrLogic);
            return CreatedAtRoute("DefaultApi", new { email = Odr.Email }, newOrder);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(Models.OrderServiceModel))]
        public IHttpActionResult DeleteOrder(int ID)
        {
            Order Odr_DAL;
            try
            {
                Odr_DAL = _OrderLogic.GetOrderByID(ID);
                //Odr_DAL = _mapper.Map<Order>(Odr);
            }
            catch
            {
                return InternalServerError();
            }
            if (Odr_DAL == null)
            {
                return NotFound();
            }

            try
            {
                _OrderLogic.DeleteOdr(Odr_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var Odr_SL = _mapper.Map<Models.OrderServiceModel>(Odr_DAL);
            return Ok(Odr_SL);
        }

    }
}