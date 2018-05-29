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
    public class PaymentMethodController : ApiController
    {
        private readonly IPaymentMethod _PaymentMethodLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public PaymentMethodController(IPaymentMethod PaymentMethodLogic, IMapper mapper)
        {
            _PaymentMethodLogic = PaymentMethodLogic;
            _mapper = mapper;
        }



        // GET: api/PaymentMethod/5

        //[Route("~/api/PaymentMethods/ID")]
        [HttpGet]
        [ResponseType(typeof(Models.PaymentMethodServiceModel))]
        public IHttpActionResult GetPaymentMethod(int ID)
        {
            PaymentMethod PM;
            try
            {
                PM = _PaymentMethodLogic.GetPaymentMethodByID(ID);
            }
            catch (Exception exe)
            {
                return InternalServerError();
            }
            if (PM == null)
            {
                return NotFound();
            }

            var PM_SL = _mapper.Map<Models.PaymentMethodServiceModel>(PM);
            return Ok(PM_SL);
        }

        public IHttpActionResult GetPaymentMethods()
        {
            try
            {
                var PaymentMethod = _mapper.Map<IEnumerable<PaymentMethodServiceModel>>(_PaymentMethodLogic.AllPM());
                return Ok(PaymentMethod);
            }
            catch
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("~/api/PaymentMethod/GetAddressByEmail/")]
        [ResponseType(typeof(Models.PaymentMethodServiceModel))]
        public IHttpActionResult GetPaymentMethodByEmail(String email)
        {
            try
            {
                var paymentmethod = _mapper.Map<IEnumerable<PaymentMethodServiceModel>>(_PaymentMethodLogic.SearchByEmail(email));
                if (paymentmethod.Any())
                {
                    return Ok(paymentmethod);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return InternalServerError();
            }

        }
        // PUT: api/PaymentMethod/5
        [ResponseType(typeof(Models.PaymentMethodServiceModel))]
        [HttpPut]
        public IHttpActionResult PutPaymentMethod(Models.PaymentMethodServiceModel PM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //PM.Email = email;

            PaymentMethod test;
            try
            {
                test = _PaymentMethodLogic.GetPaymentMethodByID(PM.id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            if (test == null)
            {
                return NotFound();
            }

            var PM_DAL = _mapper.Map<PaymentMethod>(PM);
            try
            {
                _PaymentMethodLogic.UpdatePM(PM_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                PM_DAL = null;
                PM_DAL = _mapper.Map<PaymentMethod>(PM);
                if (PM_DAL == null)
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

            var PM_SL = _mapper.Map<Models.PaymentMethodServiceModel>(PM_DAL);
            return Ok(PM_SL);
        }

        // POST: api/PaymentMethods
        [ResponseType(typeof(Models.PaymentMethodServiceModel))]
        public IHttpActionResult PostPaymentMethod(Models.PaymentMethodServiceModel PM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var PMLogic = _mapper.Map<PaymentMethod>(PM);

            try
            {
                _PaymentMethodLogic.AddPM(PMLogic);
            }
            catch (Exception exe)
            {
                return InternalServerError();
            }

            var newPaymentMethod = _mapper.Map<Models.PaymentMethodServiceModel>(PMLogic);
            return CreatedAtRoute("DefaultApi", new { email = PM.id }, newPaymentMethod);
        }

        // DELETE: api/PaymentMethods/5
        [ResponseType(typeof(Models.PaymentMethodServiceModel))]
        public IHttpActionResult DeletePaymentMethod(int ID)
        {
            PaymentMethod PM_DAL;
            try
            {
                PM_DAL = _PaymentMethodLogic.GetPaymentMethodByID(ID);
                //PM_DAL = _mapper.Map<PaymentMethod>(PM);
            }
            catch
            {
                return InternalServerError();
            }
            if (PM_DAL == null)
            {
                return NotFound();
            }

            try
            {
                _PaymentMethodLogic.DeletePM(PM_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var PM_SL = _mapper.Map<Models.PaymentMethodServiceModel>(PM_DAL);
            return Ok(PM_SL);
        }

    }
}