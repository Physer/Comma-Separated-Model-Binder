using System;
using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;

namespace Valtech.AWP.Action.Site.Infrastructure.WebApi
{
    public class CustomActionValueBinder : DefaultActionValueBinder, IActionValueBinder
    {
        public new HttpActionBinding GetBinding(HttpActionDescriptor actionDescriptor)
        {
            if (actionDescriptor.GetParameters().Any(p => p.ParameterName.Equals("codes", StringComparison
                 .InvariantCultureIgnoreCase)))
            {
                var bindings = Array.ConvertAll(actionDescriptor.GetParameters().ToArray(), new Converter<HttpParameterDescriptor, HttpParameterBinding>(GetCustomParameterBinding));
                var actionBinding = new HttpActionBinding(actionDescriptor, bindings);
                return actionBinding;

            }

            return base.GetBinding(actionDescriptor);
        }

        protected HttpParameterBinding GetCustomParameterBinding(HttpParameterDescriptor parameter)
        {
            if (parameter.ParameterType.Equals(typeof(string[])))
                return new CommaDelimitedArrayParameterBinder(parameter);


            return base.GetParameterBinding(parameter);
        }
    }
}
