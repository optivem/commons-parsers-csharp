﻿using System;

namespace Atomiv.Template.Core.Application.Commands.Products
{
    public class EditProductCommandResponse
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public decimal UnitPrice { get; set; }

        public bool IsListed { get; set; }
    }
}
