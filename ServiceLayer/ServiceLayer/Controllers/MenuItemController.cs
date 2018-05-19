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
    public class MenuItemController : ApiController
    {
        private readonly iMenuItem _menuLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public MenuItemController(iMenuItem menuLogic, IMapper mapper)
        {
            _menuLogic = menuLogic;
            _mapper = mapper;
        }

        // GET: api/MenuItems
        public IHttpActionResult GetMenuItems()
        {
            try
            {
                var menu = _mapper.Map<IEnumerable<MenuItemServiceModel>>(_menuLogic.AllMI());
                return Ok(menu);
            }
            catch
            {
                return InternalServerError();
            }
        }

        // GET: api/Restaurants/5
        [ResponseType(typeof(Models.MenuItemServiceModel))]
        public IHttpActionResult GetMenuItem(int id)
        {
            MenuItem MI;
            try
            {
                MI = _menuLogic.GetMenuItemByID(id);
            }
            catch
            {
                return InternalServerError();
            }
            if (MI == null)
            {
                return NotFound();
            }

            var MI_SL = _mapper.Map<Models.MenuItemServiceModel>(MI);
            return Ok(MI_SL);
        }

        // PUT: api/Restaurants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurant(int id, Models.MenuItemServiceModel MI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MI.itemID = id;

            MenuItem MI_DAL;
            try
            {
                MI_DAL = _menuLogic.GetMenuItemByID(id);
            }
            catch
            {
                return InternalServerError();
            }
            if (MI_DAL == null)
            {
                return NotFound();
            }
            

            try
            {
                _menuLogic.UpdateMI(MI_DAL);
            }
            catch (DbUpdateConcurrencyException)
            {
                MI_DAL = null;
                MI_DAL = _menuLogic.GetMenuItemByID(id);
                if (MI_DAL == null)
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

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/MenuItems
        [ResponseType(typeof(Models.MenuItemServiceModel))]
        public IHttpActionResult PostRestaurant(Models.MenuItemServiceModel MI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var MILogic = _mapper.Map<MenuItem>(MI);

            try
            {
                _menuLogic.AddMI(MILogic);
            }
            catch
            {
                return InternalServerError();
            }

            var newMenuItem = _mapper.Map<Models.MenuItemServiceModel>(MILogic);
            return CreatedAtRoute("DefaultApi", new { id = MI.itemName }, newMenuItem);
        }

        // DELETE: api/MenuItems/5
        [ResponseType(typeof(Models.MenuItemServiceModel))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            MenuItem MI_DAL;
            try
            {
                MI_DAL = _menuLogic.GetMenuItemByID(id);
            }
            catch
            {
                return InternalServerError();
            }
            if (MI_DAL == null)
            {
                return NotFound();
            }
            
            try
            {
                _menuLogic.DeleteMI(MI_DAL);
            }
            catch
            {
                return InternalServerError();
            }

            var MI_SL = _mapper.Map<Models.MenuItemServiceModel>(MI_DAL);
            return Ok(MI_SL);
        }

    }
}
