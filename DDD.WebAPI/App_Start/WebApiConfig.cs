using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CodeTest
{

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors(new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "*"));

            config.Routes.MapHttpRoute(
                   name: "MyApi",
                   routeTemplate: "api/{controller}/{action}/{id}",
                   defaults: new { id = RouteParameter.Optional }
               );


            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.Remove(config.Formatters.JsonFormatter);

            System.Net.Http.Formatting.JsonMediaTypeFormatter myJSONFormatter = new System.Net.Http.Formatting.JsonMediaTypeFormatter();

            myJSONFormatter.SerializerSettings.ContractResolver = new MyJsonContractResolver();

            config.Formatters.Add(myJSONFormatter);

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;


        }
    }

    public class MyJsonContractResolver : Newtonsoft.Json.Serialization.DefaultContractResolver
    {
        protected override List<System.Reflection.MemberInfo> GetSerializableMembers(Type objectType)
        {
            var members = base.GetSerializableMembers(objectType);

            var filteredMembers = new List<System.Reflection.MemberInfo>();

            members.ForEach(m =>
            {
                if (m.MemberType == System.Reflection.MemberTypes.Property)
                {
                    System.Reflection.PropertyInfo info = (System.Reflection.PropertyInfo)m;

                    if (info.PropertyType.IsPrimitive || info.PropertyType == typeof(string) || info.PropertyType == typeof(decimal) || info.PropertyType.IsGenericType && info.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    {
                        filteredMembers.Add(m);
                    }
                }
            });
            return filteredMembers;
        }
    }
}

