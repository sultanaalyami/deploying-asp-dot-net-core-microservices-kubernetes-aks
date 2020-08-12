﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GloboTicket.Web.Extensions;
using GloboTicket.Web.Models;
using GloboTicket.Web.Models.Api;
using GloboTicket.Web.Models.View;

namespace GloboTicket.Web.Services
{
    public class OrderService: IOrderService
    {
        private readonly HttpClient client;
        private readonly Settings settings;

        public OrderService(HttpClient client, Settings settings)
        {
            this.client = client;
            this.settings = settings;
        }

        public async Task<List<Order>> GetOrdersForUser(Guid userId)
        {
            var response = await client.GetAsync($"/api/order/user/{userId}");
            return await response.ReadContentAs<List<Order>>();
        }

        public async Task<Order> GetOrderDetails(Guid orderId)
        {
            var response = await client.GetAsync($"/api/order/{orderId}");
            return await response.ReadContentAs<Order>();
        }
    }
}
