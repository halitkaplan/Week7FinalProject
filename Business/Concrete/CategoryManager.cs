using Business.Abstract;
using Core.Utilities.Results;
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

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll());
        }

        // Aslında bu
        // Select * from Categories where CategoryId = 3 // 3 üm, ner gönderirsem yani.
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c=>c.CategoryId == categoryId));
        }
    }
}

