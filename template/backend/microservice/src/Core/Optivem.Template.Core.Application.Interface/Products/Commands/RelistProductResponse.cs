﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Core.Application.Products.Commands
{
    public class RelistProductResponse
    {
        public Guid Id { get; set; }

        public bool IsListed { get; set; }
    }
}
