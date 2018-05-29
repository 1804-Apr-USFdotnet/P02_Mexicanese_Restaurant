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
    public class CouponController : ApiController
    {
        private readonly ICoupon _CouponLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public CouponController(ICoupon CouponLogic, IMapper mapper)
        {
            _CouponLogic = CouponLogic;
            _mapper = mapper;
        }



        // GET: api/Coupon/5

        //[Route("~/api/Coupons/ID")]
        [HttpGet]
        [ResponseType(typeof(Models.CouponServiceModel))]
        public IHttpActionResult GetCoupon(int ID)
        {
            Coupon Cpn;
            try
            {
                Cpn = _CouponLogic.GetCouponByID(ID);
            }
            catch
            {
                return InternalServerError();
            }
            if (Cpn == null)
            {
                return NotFound();
            }

            var Cpn_SL = _mapper.Map<Models.CouponServiceModel>(Cpn);
            return Ok(Cpn_SL);
        }

        public IHttpActionResult GetCoupons()
        {
            try
            {
                var Coupon = _mapper.Map<IEnumerable<CouponServiceModel>>(_CouponLogic.AllCpn());
                return Ok(Coupon);
            }
            catch
            {
                return InternalServerError();
            }
        }
        // PUT: api/Coupon/5
        [ResponseType(typeof(Models.CouponServiceModel))]
        [HttpPut]
        public IHttpActionResult PutCoupon(Models.CouponServiceModel Cpn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          

            Coupon test;
            try
            {
                test = _CouponLogic.GetCouponByID(Cpn.id);           
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            if (test == null)
            {
                return NotFound();
            }

            var Cpn_DAL = _mapper.Map<Coupon>(Cpn);
            try
            {
                _CouponLogic.UpdateCpn(Cpn_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                Cpn_DAL = null;
                Cpn_DAL = _mapper.Map<Coupon>(Cpn);
                if (Cpn_DAL == null)
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

            var Cpn_SL = _mapper.Map<Models.CouponServiceModel>(Cpn_DAL);
            return Ok(Cpn_SL);
        }

        // POST: api/Coupons
        [ResponseType(typeof(Models.CouponServiceModel))]
        public IHttpActionResult PostCoupon(Models.CouponServiceModel Cpn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var CpnLogic = _mapper.Map<Coupon>(Cpn);

            try
            {
                _CouponLogic.AddCpn(CpnLogic);
            }
            catch
            {
                return InternalServerError();
            }

            var newCoupon = _mapper.Map<Models.CouponServiceModel>(CpnLogic);
            return CreatedAtRoute("DefaultApi", new { email = Cpn.id }, newCoupon);
        }

        // DELETE: api/Coupons/5
        [ResponseType(typeof(Models.CouponServiceModel))]
        public IHttpActionResult DeleteCoupon(int ID)
        {
            Coupon Cpn_DAL;
            try
            {
                Cpn_DAL = _CouponLogic.GetCouponByID(ID);
                //Cpn_DAL = _mapper.Map<Coupon>(Cpn);
            }
            catch
            {
                return InternalServerError();
            }
            if (Cpn_DAL == null)
            {
                return NotFound();
            }

            try
            {
                _CouponLogic.DeleteCpn(Cpn_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var Cpn_SL = _mapper.Map<Models.CouponServiceModel>(Cpn_DAL);
            return Ok(Cpn_SL);
        }

    }
}