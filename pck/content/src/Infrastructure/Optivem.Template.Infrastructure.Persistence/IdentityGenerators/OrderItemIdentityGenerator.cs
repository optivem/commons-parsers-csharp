﻿using Optivem.Atomiv.Infrastructure.SequentialGuid;
using Optivem.Template.Core.Domain.Orders;
using System;

namespace Optivem.Template.Infrastructure.Persistence.IdentityGenerators
{
    public class OrderItemIdentityGenerator : IdentityGenerator<OrderItemIdentity>
    {
        protected override OrderItemIdentity Create(Guid guid)
        {
            return new OrderItemIdentity(guid);
        }
    }
}