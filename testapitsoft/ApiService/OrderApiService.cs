using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapitsoft.Core.Dtos;
using testapitsoft.Core.Request;
using testapitsoft.Core.Response;
using testapitsoft.Helpers;

namespace testapitsoft.ApiService
{
    public class OrderApiService
    {
        private readonly SessionHelper _sessionHelper;
        private readonly ServiceHelper _serviceHelper;

        public OrderApiService(ServiceHelper serviceHelper,SessionHelper sessionHelper)
        {
            _serviceHelper = serviceHelper;
            _sessionHelper = sessionHelper;

        }

        public async Task<ApiResponse<OrderDto>> GetAllOrders(OrderDtRequest request)
        {
            var response = await _serviceHelper.PostAsync<ApiResponse<OrderDto>, OrderDtRequest>(request, "order2/getOrders", _sessionHelper.LoggedInUser.token);

            return response;
        }


    }
}
