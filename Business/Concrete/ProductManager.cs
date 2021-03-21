using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // İnjection:

        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product) 
        {
            // Ürünü eklemeden önce kodlar varsa yani şartlar varsa buraya yazılır.

            if (product.ProductName.Length<2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
           
            return new SuccessResult(Messages.ProductAdded); // bunu yapabilmenin yöntemi Constructor'dur.
        }

        // bu ne demek: ProductManager Newlendiği zaman, IProductDal referans ver diyor. Bu InMemory olabilir, entitiy olabiilir..

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>( _productDal.GetAll(),Messages.ProductsListed); 
            
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.CategoryId == id));
            // GetAll() yaptığımda uyarı ekranı olarak bana bir Expression ver diyor program. Yani bana bir lamda ver diyor. => (lamda)
        }
        
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>( _productDal.Get(p=>p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            // if (DateTime.Now.Hour == 16)
            // {
            //    return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            // }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
