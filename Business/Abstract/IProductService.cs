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
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);   // e-ticaret sisteminde, sol tarafta kategoriyi seçtiğimde, kategori numarasına göre
                                                    // göre getiren olayı yazıyoruz.

        List<Product> GetByUnitPrice(decimal min, decimal max);

        List<ProductDetailDto> GetProductDetails();

    }
}
