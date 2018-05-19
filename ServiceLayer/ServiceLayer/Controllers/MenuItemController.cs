using AutoMapper;
using AutoMapper.QueryableExtensions;
using NLog;
using System;
using System.Collections.Generic;
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

    }
}
