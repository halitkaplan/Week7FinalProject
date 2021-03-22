using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("bu bir doğrulama sınıfı değildir.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);       // burası Reflection, Reflection: çalışma anında, bir şeyleri çalıştırabilmeyi sağlıyor.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];          // sonra, productvalidator'ın tiplerinden generigargumanlarından ilgini bul ve onun parametrelerini bul.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);  // invocation method demek: methodun parametrelirine bak. entityTypeye denk gelen, validator tipine eşit olan parametrelerini bul diyor.(Product)
                                                                                        
            foreach (var entity in entities)                                            // birden fazla validation olabilir. her birini tek tek gez.
            {
                ValidationTool.Validate(validator, entity);                             // validate et.
            }   
        }
    }
}
