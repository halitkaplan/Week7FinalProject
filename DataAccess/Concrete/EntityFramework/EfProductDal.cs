using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())   // join atacağım için 
            {
                var result = from p in context.Products             // context bizim tablomuza karşılık geliyor.
                             join c in context.Categories           // ürünlerle categorileri join ediyor.
                             on p.CategoryId equals c.CategoryId    // p de ki categoryId ile, c de ki categoryId eşitse, ürünlerle kategorileri join et
                             select new ProductDetailDto 
                             {
                                 ProductId=p.ProductId, 
                                 ProductName=p.ProductName, 
                                 CategoryName=c.CategoryName, 
                                 UnitsInStock=p.UnitsInStock 
                             };       // Hangi kolonları istiyorsak; Yani sonucu şu kolonlara uydurarak ver.

                return result.ToList(); // result, bir döngü türü. IQUerable. 
            }
            
        }
    }
}

