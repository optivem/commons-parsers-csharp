﻿using Atomiv.Core.Common.Http;
using System;
using System.Threading.Tasks;

namespace Atomiv.Infrastructure.AspNetCore
{
    public class BaseHttpService<TService> : IHttpControllerClient where TService : IHttpControllerClient
    {
        public BaseHttpService(TService service)
        {
            Service = service;
        }

        public TService Service { get; }

        protected async Task<TResponse> ExecuteAsync<TResponse>(Func<TService, Task<ObjectClientResponse<TResponse>>> action)
        {
            var response = await action(Service);

            if (!response.IsSuccessStatusCode)
            {
                throw new ErrorException(response);
            }

            return response.Data;
        }
    }
}