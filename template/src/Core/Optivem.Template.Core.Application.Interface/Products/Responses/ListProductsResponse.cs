﻿using Optivem.Core.Application;
using System.Collections.Generic;

namespace Optivem.Template.Core.Application.Products
{
    public class ListProductsResponse : ICollectionResponse<ListProductsRecordResponse, int>
    {
        public List<ListProductsRecordResponse> Records { get; set; }

        public int Count { get; set; }
    }

    public class ListProductsRecordResponse : IResponse<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}