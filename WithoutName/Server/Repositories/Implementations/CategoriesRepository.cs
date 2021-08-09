using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.Models;
using Server.Repositories.Interfaces;

namespace Server.Repositories.Implementations
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private List<Category> _Categories = new List<Category>();
        void ICategoriesRepository.AddUCategory(Category Category)
        {
            _Categories.Add(Category);
        }

        List<Category> ICategoriesRepository.Get(int id)
        {
            return _Categories.Where(x => x.Id == id).ToList();
        }

        List<Category> ICategoriesRepository.GetAll()
        {
            return _Categories;
        }

        void ICategoriesRepository.RemoveCategory(int id)
        {
            _Categories.Remove(_Categories.Where(x => x.Id == id).FirstOrDefault());
        }
    }
}
