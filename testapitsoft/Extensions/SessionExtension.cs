using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testapitsoft.Extensions
{
    public static class SessionExtension
    {
        #region Set Object

        public static void SetObject(this ISession session, string key, object value)
        {
            session.Set(key, Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value)));
        }

        #endregion

        #region Get Object

        public static T GetObject<T>(this ISession session, string key) where T : class
        {
            bool isget = session.TryGetValue(key, out var outObject);
            return !isget || outObject == null ? null : JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(outObject));
        }

        #endregion
    }
}
