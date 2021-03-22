using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty();       // boş olamaz
            RuleFor(p => p.ProductName).MinimumLength(2);   // minimum 2 karakter olmalı
            RuleFor(p => p.UnitPrice).NotEmpty();         // boş olamaz
            RuleFor(p => p.UnitPrice).GreaterThan(0);     // 0 dan büyük olmalı

            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);



            
            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürünler A Harfi İle başlamalı!"); // buradaki StartWithA aslında bizim methodumuz.
                                                          // ampülden tıklayarak generate method diyelim

        }

        private bool StartWithA(string arg)     // buradaki bool, true döndürürsem kurala uygun, false gönderirsem patla. buradaki arg, gönderdiğimiz NroductName
        {
            return arg.StartsWith("A");
        }
    }
}


