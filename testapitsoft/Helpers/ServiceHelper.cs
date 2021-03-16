using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace testapitsoft.Helpers
{
    public class ServiceHelper
    {
        public async Task<TResponse> PostAsync<TResponse,TRequest>(TRequest request,string action,string token)
        {
            try
            {
                var baseUrl = "http://cemkirlibal.1ticaret.com/rest1/";
                var client = new RestClient(baseUrl);

                var restRequest = new RestRequest(action, Method.POST);

                if (token!=null)
                {
                    restRequest.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                }
                restRequest.AddParameter("token", token);
                restRequest.AddObject(request);

                client.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;

                var response = await client.ExecuteAsync(restRequest);

                var result = JsonConvert.DeserializeObject<TResponse>(response.Content);

                return result;

                 

            }
            catch (Exception exception)
            {

                throw;
            }
        }  


    }
}
