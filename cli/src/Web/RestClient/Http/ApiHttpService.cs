﻿using Optivem.Framework.Core.Common.Http;
using Optivem.Framework.Infrastructure.AspNetCore;
using Optivem.Cli.Web.RestClient.Interface;

namespace Optivem.Cli.Web.RestClient.Http
{
    public class ApiHttpService : BaseApiClient, IApiHttpService
    {
        public ApiHttpService(IControllerClientFactory clientFactory)
            : base(clientFactory)
        {
            MyFoos = new MyFooHttpService(clientFactory);
        }

        public IMyFooHttpService MyFoos { get; }
    }
}