using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private readonly MexicaneseModel _repoContext;
        public MenuItemRepository(MexicaneseModel context)
        {
            _repoContext = context;
        }

        public MenuItem GetById(int id)
        {
            return _repoContext.MenuItems.Find(id);
        }

        public void AddMenuItem(MenuItem MI)
        {
            _repoContext.MenuItems.Add(MI);
            _repoContext.SaveChanges();
        }

        public void DeleteMenuItem(MenuItem MI)
        {
            var delete = _repoContext.MenuItems.Find(MI.itemID);
            _repoContext.MenuItems.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<MenuItem> GetAllMenuItems()
        {
            return _repoContext.MenuItems;
        }
        
        public void ModifyMenuItem(MenuItem MI)
        {
            var modify = _repoContext.MenuItems.Find(MI.itemID);
            _repoContext.Entry(modify).CurrentValues.SetValues(MI);
            _repoContext.SaveChanges();
        }

        public void SaveMenuItems()
        {
            _repoContext.SaveChanges();
        }
    }
}
