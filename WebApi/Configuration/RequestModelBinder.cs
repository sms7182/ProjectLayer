using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace ITDAPi.Configuration
{
   public class RequestModelBinder : IModelBinder
    {

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {

         

            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            // Specify a default argument name if none is set by ModelBinderAttribute
            var modelName = bindingContext.ModelName;
            if (string.IsNullOrEmpty(modelName))
            {
                modelName = "model";
            }

            // Try to fetch the value of the argument by name
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            bindingContext.ModelState.SetModelValue(modelName, valueProviderResult);

            var value = valueProviderResult.FirstValue;
            // Check if the argument value is null or empty
            if (String.IsNullOrEmpty(value))
            {
                return Task.CompletedTask;
            }


            var modelElementType = bindingContext.ModelMetadata.ElementType;
            //  var model = reader.GetRecords(modelElementType).ToList();
           // var val = JsonConvert.DeserializeObject<Request>(valueProviderResult.FirstValue);
           // bindingContext.Result = ModelBindingResult.Success(val);

            return Task.CompletedTask;
        }
    }
}