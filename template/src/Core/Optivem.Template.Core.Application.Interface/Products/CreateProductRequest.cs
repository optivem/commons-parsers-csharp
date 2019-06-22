﻿using Optivem.Core.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Products
{
    public class CreateProductRequest : IRequest
    {
        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
