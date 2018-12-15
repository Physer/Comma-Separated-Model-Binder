using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Metadata;
using System.Web.Http.ModelBinding;
using System.Web.Http.ValueProviders;
using System.Web.Http.ValueProviders.Providers;

namespace Valtech.AWP.Action.Site.Infrastructure.WebApi
{
    public class CommaDelimitedArrayParameterBinder : HttpParameterBinding, IValueProviderParameterBinding
    {
        public CommaDelimitedArrayParameterBinder(HttpParameterDescriptor desc)
            : base(desc)
        {
        }

        /// <summary>
        /// Handles Binding (Converts a comma delimited string into an array of integers)
        /// </summary>
        public override Task ExecuteBindingAsync(ModelMetadataProvider metadataProvider,
                                                 HttpActionContext actionContext,
                                                 CancellationToken cancellationToken)
        {
            try
            {
                var queryString = actionContext.Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
                foreach(var value in queryString.Values)
                {
                        var splitString = value.Split(',').ToArray();
                        if (splitString != null && splitString.Any())
                            SetValue(actionContext, splitString);

                        return Task.CompletedTask;
                }
            }
            catch
            {
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        public IEnumerable<ValueProviderFactory> ValueProviderFactories { get; } = new[] { new QueryStringValueProviderFactory() };
    }
}
