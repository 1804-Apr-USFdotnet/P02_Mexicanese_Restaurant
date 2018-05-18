using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IMenuItemRepository
    {
        MenuItem GetById(int id);
        IEnumerable<MenuItem> GetAllMenuItems();
        void AddMenuItem(MenuItem MI);
        void ModifyMenuItem(MenuItem MI);
        void DeleteMenuItem(MenuItem MI);
        void SaveMenuItems();
    }
}
