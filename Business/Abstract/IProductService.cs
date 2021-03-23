using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {

        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);   // e-ticaret sisteminde, sol tarafta kategoriyi seçtiğimde, kategori numarasına göre
                                                                 // göre getiren olayı yazıyoruz.

        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();

        IDataResult<Product>  GetById(int productId); // bu bizim için
                                        // sadece product döndürüyor.
                                        // bir tane gösteriyor yani bize.
                                        // mesela ürüne girdik
                                        // o ürüne ait tüm bilgileri gösteriyor bize.

        IResult Add(Product product); 
        IResult Update(Product product); 

    }
}
