﻿using Atomiv.Core.Common.Http;
using Atomiv.Infrastructure.AspNetCore;
using Generator.Core.Application.Products.Requests;
using Generator.Core.Application.Products.Responses;
using Generator.Web.RestClient.Interface;
using System.Threading.Tasks;

namespace Generator.Web.RestClient.Http
{
    public class ProductHttpService : BaseControllerClient, IProductHttpService
    {
        public ProductHttpService(IControllerClientFactory clientFactory) 
            : base(clientFactory, "api/products")
        {
        }

        public Task<IObjectClientResponse<BrowseProductsResponse>> BrowseProductsAsync(BrowseProductsRequest request)
        {
            return Client.GetAsync<BrowseProductsRequest, BrowseProductsResponse>(request);
        }

        public Task<IObjectClientResponse<CreateProductResponse>> CreateProductAsync(CreateProductRequest request)
        {
            return Client.PostAsync<CreateProductRequest, CreateProductResponse>(request);
        }

        public Task<IObjectClientResponse<FindProductResponse>> FindProductAsync(FindProductRequest request)
        {
            var id = request.Id;
            return Client.GetByIdAsync<int, FindProductResponse>(id);
        }

        public Task<IObjectClientResponse<ListProductsResponse>> ListProductsAsync(ListProductsRequest request)
        {
            return Client.GetAsync<ListProductsResponse>("list");
        }

        public Task<IObjectClientResponse<RelistProductResponse>> RelistProductAsync(RelistProductRequest request)
        {
            return Client.PostAsync<RelistProductRequest, RelistProductResponse>(request);
        }

        public Task<IObjectClientResponse<UnlistProductResponse>> UnlistProductAsync(UnlistProductRequest request)
        {
            return Client.PostAsync<UnlistProductRequest, UnlistProductResponse>(request);
        }

        public Task<IObjectClientResponse<UpdateProductResponse>> UpdateProductAsync(UpdateProductRequest request)
        {
            return Client.PutByIdAsync<int, UpdateProductRequest, UpdateProductResponse>(request.Id, request);
        }
    }
}
