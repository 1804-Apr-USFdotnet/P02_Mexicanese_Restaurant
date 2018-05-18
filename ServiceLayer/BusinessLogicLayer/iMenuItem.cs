using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface iMenuItem
    {   //add getAllSectionItems later, need migration to update model
        List<MenuItem> AllMI();
        MenuItem GetMenuItemByID(int id);
        void AddMI(MenuItem MI);
        void UpdateMI(MenuItem MI);
        void DeleteMI(MenuItem MI);
    }
}
