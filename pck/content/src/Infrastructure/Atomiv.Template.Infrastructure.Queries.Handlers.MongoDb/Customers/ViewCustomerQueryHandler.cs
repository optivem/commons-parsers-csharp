﻿using Atomiv.Core.Application;
using Atomiv.Template.Core.Application.Queries.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB.Records;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Queries.Handlers.MongoDB.Customers
{
    public class ViewCustomerQueryHandler : QueryHandler<ViewCustomerQuery, ViewCustomerQueryResponse>
    {
        public ViewCustomerQueryHandler(DatabaseContext context) : base(context)
        {
        }

        public override async Task<ViewCustomerQueryResponse> HandleAsync(ViewCustomerQuery query)
        {
            var customerRecordId = query.Id;

            var customerRecord = await Context.Customers
                .Find(e => e.Id == customerRecordId)
                .FirstOrDefaultAsync();

            if (customerRecord == null)
            {
                throw new ExistenceException();
            }

            return GetResponse(customerRecord);
        }

        private ViewCustomerQueryResponse GetResponse(CustomerRecord customerRecord)
        {
            var id = customerRecord.Id;
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            // TODO: VC: Fill in

            /*

            var openOrders = customerRecord.Orders
                .Where(e => e.OrderStatusId != OrderStatus.Shipped
                    || e.OrderStatusId != OrderStatus.Cancelled)
                .Count();

            var lastOrderDate = customerRecord.Orders
                .Max(e => (DateTime?)e.OrderDate);

            var totalOrders = customerRecord.Orders
                .Count;

            var totalOrderValue = customerRecord.Orders
                .SelectMany(e => e.OrderItems)
                .Select(e => e.UnitPrice * e.Quantity)
                .Sum(e => (decimal?)e)
                .GetValueOrDefault();

            var topProducts = customerRecord.Orders
                .SelectMany(e => e.OrderItems)
                .GroupBy(e => e.Product)
                .OrderByDescending(e => e.Count())
                .Select(e => e.Key.ProductName)
                .ToList();

            */

            var openOrders = 0;
            var lastOrderDate = DateTime.MinValue;
            var totalOrders = 2;
            var totalOrderValue = 30.25m;
            var topProducts = new List<string>();

            return new ViewCustomerQueryResponse
            {
                Id = id,
                FirstName = firstName,
                LastName = lastName,
                OpenOrders = openOrders,
                LastOrderDate = lastOrderDate,
                TotalOrders = totalOrders,
                TotalOrderValue = totalOrderValue,
                TopProducts = topProducts
            };
        }
    }
}
