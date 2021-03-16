using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapitsoft.Core.Dtos;
using testapitsoft.Core.Response;
using testapitsoft.Helpers;
using testapitsoft.Models;

namespace testapitsoft.ApiService
{
    public class AuthApiService
    {
        private readonly SessionHelper _sessionHelper;
        private readonly ServiceHelper _serviceHelper;

        public AuthApiService(ServiceHelper serviceHelper,SessionHelper sessionHelper)
        {
            _serviceHelper = serviceHelper;
            _sessionHelper = sessionHelper;
        }

        public async Task<ApiResponse<AuthDto>> Login(LoginModel request)
        {
            var response = await _serviceHelper.PostAsync<ApiResponse<AuthDto>, LoginModel>(request, "auth/login/tsoft", null);

            return response;
        }


    }
}
