using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogicLayer
{
    public class MenuItemLogic : iMenuItem
    {
        private readonly IMenuItemRepository _MIRepo;
        public MenuItemLogic(IMenuItemRepository MIRepo)
        {
            _MIRepo = MIRepo;
        }
        public void AddMI(MenuItem MI)
        {
            _MIRepo.AddMenuItem(MI);
        }

        public List<MenuItem> AllMI()
        {
            return _MIRepo.GetAllMenuItems().ToList();
        }

        public void DeleteMI(MenuItem MI)
        {
            _MIRepo.DeleteMenuItem(MI);
        }

        public MenuItem GetMenuItemByID(int id)
        {
           return _MIRepo.GetById(id);
        }

        public void UpdateMI(MenuItem MI)
        {
            _MIRepo.ModifyMenuItem(MI);
        }
    }
}
