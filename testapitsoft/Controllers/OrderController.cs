using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using testapitsoft.ApiService;
using testapitsoft.Core.Dtos;
using testapitsoft.Core.Request;
using testapitsoft.Core.Service;
using testapitsoft.Models;

namespace testapitsoft.Controllers
{
    public class OrderController : Controller
    {
        private readonly OrderApiService _orderApiService;
        private readonly IOrderService _orderService;

        public OrderController(OrderApiService orderApiService,IOrderService orderService)
        {
            _orderApiService = orderApiService;
            _orderService = orderService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new OrderDtRequest();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetAllOrders(OrderDtRequest request)
        {
            var response = await _orderApiService.GetAllOrders(request);
            var search = await _orderService.GetAllAsync();

            var model = new OrderViewModel();

            if (response.Data!=null)
            {
                //var order = await _orderService.GetByIdAsync(response.Data.FirstOrDefault().CustomerId);

                if (true)
                {
                    await _orderService.AddAsync(response.Data.FirstOrDefault());
                }

                var orders = await _orderService.GetAllAsync();

                model.Orders = orders.ToList();
            }
            else
            {
                return View(search);
            }
            return View(model);
        }
            
        public async Task<IActionResult> Add()
        {
            var model = new OrderDto();

            return View(model);
            
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderDto orderDto)
        {
            if (orderDto!=null)
            {
                await _orderService.AddAsync(orderDto);
            }
            return View(orderDto);
        }


        public async Task<IActionResult> Update(int id)
        {
            var orders = await _orderService.GetByIdAsync(id);
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> Update(OrderDto orderDto)
        {
            await _orderService.UpdateAsync(orderDto);
            return View(orderDto);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(OrderDto orderDto)
        {
            await _orderService.DeleteAsync(orderDto);
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var order = await _orderService.GetByIdAsync(id);


            return View(order);
        }



        


    }
}
