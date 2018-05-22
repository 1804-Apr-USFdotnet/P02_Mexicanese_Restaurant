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
    public class AddressController : ApiController
    {
        private readonly IAddress _AddressLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AddressController(IAddress AddressLogic, IMapper mapper)
        {
            _AddressLogic = AddressLogic;
            _mapper = mapper;
        }



        // GET: api/Address/5

        //[Route("~/api/Addresss/ID")]
        [HttpGet]
        [ResponseType(typeof(Models.AddressServiceModel))]
        public IHttpActionResult GetAddress(int ID)
        {
            Address Addr;
            try
            {
                Addr = _AddressLogic.GetAddressByID(ID);
            }
            catch
            {
                return InternalServerError();
            }
            if (Addr == null)
            {
                return NotFound();
            }

            var Addr_SL = _mapper.Map<Models.AddressServiceModel>(Addr);
            return Ok(Addr_SL);
        }

        public IHttpActionResult GetAddresss()
        {
            try
            {
                var Address = _mapper.Map<IEnumerable<AddressServiceModel>>(_AddressLogic.AllAddr());
                return Ok(Address);
            }
            catch
            {
                return InternalServerError();
            }
        }
        // PUT: api/Address/5
        [ResponseType(typeof(Models.AddressServiceModel))]
        [HttpPut]
        public IHttpActionResult PutAddress(Models.AddressServiceModel Addr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Addr.Email = email;

            Address test;
            try
            {
                test = _AddressLogic.GetAddressByID(Addr.id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            if (test == null)
            {
                return NotFound();
            }

            var Addr_DAL = _mapper.Map<Address>(Addr);
            try
            {
                _AddressLogic.UpdateAddr(Addr_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                Addr_DAL = null;
                Addr_DAL = _mapper.Map<Address>(Addr);
                if (Addr_DAL == null)
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

            var Addr_SL = _mapper.Map<Models.AddressServiceModel>(Addr_DAL);
            return Ok(Addr_SL);
        }

        // POST: api/Addresss
        [ResponseType(typeof(Models.AddressServiceModel))]
        public IHttpActionResult PostAddress(Models.AddressServiceModel Addr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var AddrLogic = _mapper.Map<Address>(Addr);

            try
            {
                _AddressLogic.AddAddr(AddrLogic);
            }
            catch
            {
                return InternalServerError();
            }

            var newAddress = _mapper.Map<Models.AddressServiceModel>(AddrLogic);
            return CreatedAtRoute("DefaultApi", new { email = Addr.id }, newAddress);
        }

        // DELETE: api/Addresss/5
        [ResponseType(typeof(Models.AddressServiceModel))]
        public IHttpActionResult DeleteAddress(int ID)
        {
            Address Addr_DAL;
            try
            {
                Addr_DAL = _AddressLogic.GetAddressByID(ID);
                //Addr_DAL = _mapper.Map<Address>(Addr);
            }
            catch
            {
                return InternalServerError();
            }
            if (Addr_DAL == null)
            {
                return NotFound();
            }

            try
            {
                _AddressLogic.DeleteAddr(Addr_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var Addr_SL = _mapper.Map<Models.AddressServiceModel>(Addr_DAL);
            return Ok(Addr_SL);
        }

    }
}