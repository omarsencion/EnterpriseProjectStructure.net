namespace Org.Domain.WebApi
{
    using System.IO;
    using System.Linq;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Newtonsoft.Json;

    public static class ControllerRelatedExtensions
    {
        public static void Verify(this ModelStateDictionary modelStateDictionary)
        {
            if (!modelStateDictionary.IsValid)
            {
                string messages = string.Join("; ", modelStateDictionary.Values
                                          .SelectMany(x => x.Errors)
                                          .Select(x => string.IsNullOrEmpty(x.ErrorMessage) ? x.Exception?.Message : x.ErrorMessage));

                throw new System.Exception(messages);
            }
        }

        public static string ReadBody(this HttpRequest request)
        {
            request.Body.Position = 0;

            StreamReader reader = new StreamReader(request.Body);
            return reader.ReadToEnd();
        }

        public static T GetObject<T>(this HttpRequest request, string key) where T : class
        {
            string jsonString = request.Form[key];
            return JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings
            {
                Culture = System.Globalization.CultureInfo.CurrentCulture
            });
        }
    }
}
