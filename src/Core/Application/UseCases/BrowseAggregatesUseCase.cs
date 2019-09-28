﻿using Optivem.Framework.Core.Application.UseCases.Base;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Optivem.Framework.Core.Application
{
    public class BrowseAggregatesUseCase<TRepository, TRequest, TResponse, TRecordResponse, TAggregateRoot, TIdentity, TId>
        : RepositoryUseCase<TRepository, TRequest, TResponse>
        where TRepository : IPageAggregatesRepository<TAggregateRoot, TIdentity>
        where TRequest : ICollectionRequest
        where TResponse : ICollectionResponse<TRecordResponse, TId>, new()
        where TRecordResponse : IResponse<TId>
        where TAggregateRoot : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity<TId>
    {
        public BrowseAggregatesUseCase(IMapper mapper, TRepository repository) 
            : base(mapper, repository)
        {
        }

        public override async Task<TResponse> HandleAsync(TRequest request)
        {
            var aggregateRoots = await Repository.PageAsync(request.Page, request.Size);

            return Mapper.Map<IEnumerable<TAggregateRoot>, TResponse>(aggregateRoots);
        }
    }
}
