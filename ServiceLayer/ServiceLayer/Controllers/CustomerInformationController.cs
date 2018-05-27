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
    public class CustomerInformationController : ApiController
    {
        private readonly ICustomerInformation _CustomerInformationLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CustomerInformationController(ICustomerInformation CustomerInformationLogic, IMapper mapper)
        {
            _CustomerInformationLogic = CustomerInformationLogic;
            _mapper = mapper;
        }

        // GET: api/CustomerInformations
        public IHttpActionResult GetCustomerInformations()
        {
            try
            {
                var CustomerInformation = _mapper.Map<IEnumerable<CustomerInformationServiceModel>>(_CustomerInformationLogic.AllCustInfo());
                return Ok(CustomerInformation);
            }
            catch
            {
                return InternalServerError();
            }
        }

        // GET: api/Restaurants/5
        [ResponseType(typeof(Models.CustomerInformationServiceModel))]
        public IHttpActionResult GetCustomerInformation(String email)
        {
            CustomerInformation CustInfo;
            try
            {
                CustInfo = _CustomerInformationLogic.GetCustomerInformationByEmail(email);
            }
            catch
            {
                return InternalServerError();
            }
            if (CustInfo == null)
            {
                return NotFound();
            }

            var CustInfo_SL = _mapper.Map<Models.CustomerInformationServiceModel>(CustInfo);
            return Ok(CustInfo_SL);
        }

        // PUT: api/CustomerInformation/5
        [ResponseType(typeof(Models.CustomerInformationServiceModel))]
        [HttpPut]
        public IHttpActionResult PutCustomerInformation(Models.CustomerInformationServiceModel CustInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //CustInfo.Email = email;


            try
            {
                var test = _CustomerInformationLogic.GetCustomerInformationByEmail(CustInfo.Email);
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            if (_CustomerInformationLogic.GetCustomerInformationByEmail(CustInfo.Email) == null)
            {
                return NotFound();
            }

            var CustInfo_DAL = _mapper.Map<CustomerInformation>(CustInfo);
            try
            {
                _CustomerInformationLogic.UpdateCustInfo(CustInfo_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                CustInfo_DAL = null;
                CustInfo_DAL = _mapper.Map<CustomerInformation>(CustInfo);
                if (CustInfo_DAL == null)
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

            var CustInfo_SL = _mapper.Map<Models.CustomerInformationServiceModel>(CustInfo_DAL);
            return Ok(CustInfo_SL);
        }

        // POST: api/CustomerInformations
        [ResponseType(typeof(Models.CustomerInformationServiceModel))]
        public IHttpActionResult PostCustomerInformation(Models.CustomerInformationServiceModel CustInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CustInfoLogic = _mapper.Map<CustomerInformation>(CustInfo);

            try
            {
                _CustomerInformationLogic.AddCustInfo(CustInfoLogic);
            }
            catch
            {
                return InternalServerError();
            }

            var newCustomerInformation = _mapper.Map<Models.CustomerInformationServiceModel>(CustInfoLogic);
            return CreatedAtRoute("DefaultApi", new { email = CustInfo.Email }, newCustomerInformation);
        }

        // DELETE: api/CustomerInformations/5
        [ResponseType(typeof(Models.CustomerInformationServiceModel))]
        public IHttpActionResult DeleteCustomerInformation(CustomerInformationServiceModel CustInfo)
        {
            CustomerInformation CustInfo_DAL;
            try
            {
                //CustInfo_DAL = _CustomerInformationLogic.GetCustomerInformationByEmail(email);
                CustInfo_DAL = _mapper.Map<CustomerInformation>(CustInfo);
            }
            catch
            {
                return InternalServerError();
            }
            if (CustInfo_DAL == null)
            {
                return NotFound();
            }

            try
            {
                _CustomerInformationLogic.DeleteCustInfo(CustInfo_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var CustInfo_SL = _mapper.Map<Models.CustomerInformationServiceModel>(CustInfo_DAL);
            return Ok(CustInfo_SL);
        }

    }
}