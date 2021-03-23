﻿using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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
        ICategoryService _categoryService;        

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;

        }



        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product) 
        {
           IResult result = BusinessRules.Run(CheckIfProductNameExists(product.ProductName),
                                          CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                                          CheckIfCategoryLimitExceded());

            // bunu bi result2a atadım.

            if (result!=null)   //  eğer result, kurala uymayan bir durum oluştuysa,
            {
                return result;  // o zaman result'ı döndürebilirim.
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);          
         
            
        }



        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }




        // bu ne demek: ProductManager Newlendiği zaman, IProductDal referans ver diyor. Bu InMemory olabilir, entitiy olabiilir.

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour==22)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}

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


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();   // Any var mı demek. buna uyan kayıt var mı demek.
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll(); // tümünü getiriyor zaten
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }




    }





}
