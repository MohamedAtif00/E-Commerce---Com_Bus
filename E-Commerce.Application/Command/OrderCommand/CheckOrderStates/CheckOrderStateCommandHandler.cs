using Ardalis.Result;
using E_Commerce.Domain.Common;
using E_Commerce.SharedKernal.Application;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Application.Command.OrderCommand.CheckOrderStates
{
    public class CheckOrderStateCommandHandler : ICommandHandler<CheckOrdersStateCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly HttpClient _httpClient;

        public CheckOrderStateCommandHandler(IUnitOfWork unitOfWork, HttpClient httpClient)
        {
            _unitOfWork = unitOfWork;
            _httpClient = httpClient;
        }

        public async Task<Result> Handle(CheckOrdersStateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Get the token asynchronously
                var shipmentInfo = await _unitOfWork.ShipmentInformationRepository.GetInfo();

                var token = RemoveFirstBearer(shipmentInfo.Token);

                // Set the Authorization header
                //_httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                var orders = await _unitOfWork.OrderRepository.GetOrdersInProcess();

                foreach (var order in orders)
                {
                    if (order.TrackingNumber != null)
                    {

                        // Create a new HttpRequestMessage
                        var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"http://app.bosta.co/api/v2/deliveries/business/{order.TrackingNumber}");

                        // Set the Authorization header specifically for this request
                        requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

                        // Send the request
                        var response = await _httpClient.SendAsync(requestMessage);

                        response.EnsureSuccessStatusCode(); 
                        // Handle the response
                        if (response.IsSuccessStatusCode)
                        {
                            // Process the response
                            var responseData = await response.Content.ReadAsStringAsync();
                            // Handle response data...
                        }
                        else
                        {
                            // Handle error response
                            var errorMessage = await response.Content.ReadAsStringAsync();
                            // Log or throw an exception based on the error
                        }

                        response.EnsureSuccessStatusCode();
                        order.MakeCheck();
                        var result =  await response.Content.ReadAsStringAsync();
                    }
                }

                await _unitOfWork.save();

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Error();
            }
        }




        public static string RemoveFirstBearer(string token)
        {
            // Check if the token starts with "Bearer "
            if (token.StartsWith("Bearer "))
            {
                // Remove the first occurrence of "Bearer "
                return  token.Substring("Bearer ".Length).TrimStart();
            }

            return token; // Return the original token if it doesn't start with "Bearer "
        }


    }
}
