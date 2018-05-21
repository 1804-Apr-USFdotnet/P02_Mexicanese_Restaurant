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
    public class UserController : ApiController
    {
        private readonly IUser _userLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public UserController(IUser userLogic, IMapper mapper)
        {
            _userLogic = userLogic;
            _mapper = mapper;
        }

        // GET: api/Users
        public IHttpActionResult GetUsers()
        {
            try
            {
                var user = _mapper.Map<IEnumerable<UserServiceModel>>(_userLogic.AllUsr());
                return Ok(user);
            }
            catch
            {
                return InternalServerError();
            }
        }

        // GET: api/Restaurants/5
        [ResponseType(typeof(Models.UserServiceModel))]
        public IHttpActionResult GetUser(String email)
        {
            User Usr;
            try
            {
                Usr = _userLogic.GetUserByEmail(email);
            }
            catch
            {
                return InternalServerError();
            }
            if (Usr == null)
            {
                return NotFound();
            }

            var Usr_SL = _mapper.Map<Models.UserServiceModel>(Usr);
            return Ok(Usr_SL);
        }

        // PUT: api/User/5
        [ResponseType(typeof(Models.UserServiceModel))]
        [HttpPut]
        public IHttpActionResult PutUser(Models.UserServiceModel Usr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Usr.Email = email;

            
            try
            {
                var test = _userLogic.GetUserByEmail(Usr.Email);
            }
            catch (DbUpdateConcurrencyException)
            {
                return InternalServerError();
            }
            if(_userLogic.GetUserByEmail(Usr.Email) == null)
            {
                return NotFound();
            }

            var Usr_DAL = _mapper.Map<User>(Usr);
            try
            {
                _userLogic.UpdateUsr(Usr_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                Usr_DAL = null;
                Usr_DAL = _mapper.Map<User>(Usr);
                if (Usr_DAL == null)
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

            var Usr_SL = _mapper.Map<Models.UserServiceModel>(Usr_DAL);
            return Ok(Usr_SL);
        }

        // POST: api/Users
        [ResponseType(typeof(Models.UserServiceModel))]
        public IHttpActionResult PostUser(Models.UserServiceModel Usr)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var UsrLogic = _mapper.Map<User>(Usr);

            try
            {
                _userLogic.AddUsr(UsrLogic);
            }
            catch
            {
                return InternalServerError();
            }

            var newUser = _mapper.Map<Models.UserServiceModel>(UsrLogic);
            return CreatedAtRoute("DefaultApi", new { email = Usr.Email }, newUser);
        }
        
        // DELETE: api/Users/5
        [ResponseType(typeof(Models.UserServiceModel))]
        public IHttpActionResult DeleteUser(UserServiceModel Usr)
        {
            User Usr_DAL;
            try
            {
                //Usr_DAL = _userLogic.GetUserByEmail(email);
                Usr_DAL = _mapper.Map<User>(Usr);
            }
            catch
            {
                return InternalServerError();
            }
            if (Usr_DAL == null)
            {
                return NotFound();
            }

            try
            {
                _userLogic.DeleteUsr(Usr_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var Usr_SL = _mapper.Map<Models.UserServiceModel>(Usr_DAL);
            return Ok(Usr_SL);
        }

    }
}