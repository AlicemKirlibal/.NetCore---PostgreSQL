using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapitsoft.Core.Dtos;
using testapitsoft.Extensions;

namespace testapitsoft.Helpers
{
    public class SessionHelper
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly string LoggedInUserKey = "41A6B5D4-B4D1-44BF-AD3B-C39276A3AF81";

        public SessionHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public AuthDto LoggedInUser
        {
            get
            {
                var result = _httpContextAccessor.HttpContext.Session.GetObject<AuthDto>(LoggedInUserKey);
                return result;

            }

            set => _httpContextAccessor.HttpContext.Session.SetObject(LoggedInUserKey, value);
        }

        public AuthDto Login(AuthDto data)
        {
            LoggedInUser = data;
            return LoggedInUser;
        }


    }
}
