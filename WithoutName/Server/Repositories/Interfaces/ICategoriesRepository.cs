using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;

namespace Server.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        List<Category> GetAll();
        List<Category> Get(int id);
        void AddUCategory(Category ategory);
        void RemoveCategory(int id);
    }
}
