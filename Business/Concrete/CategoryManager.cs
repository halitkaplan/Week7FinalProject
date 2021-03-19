using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal) // Ben CategoryOlarak veri erişime bağımlıyım ama 
        {                                               // DataAccess içinde istediğin gibi at koşturabilirsin. ama benim 
            _categoryDal = categoryDal;                  // kurallarıma uy diyoruz.
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        // Aslında bu
        // Select * from Categories where CategoryId = 3 // 3 üm, ner gönderirsem yani.
        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId == categoryId);
        }
    }
}

