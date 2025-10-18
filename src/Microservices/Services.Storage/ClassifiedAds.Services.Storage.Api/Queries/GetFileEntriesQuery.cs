﻿using ClassifiedAds.Application;
using ClassifiedAds.Domain.Repositories;
using ClassifiedAds.Services.Storage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ClassifiedAds.Services.Storage.Queries;

public class GetFileEntriesQuery : IQuery<List<FileEntry>>
{
}

public class GetFileEntriesQueryHandler : IQueryHandler<GetFileEntriesQuery, List<FileEntry>>
{
    private readonly IRepository<FileEntry, Guid> _repository;

    public GetFileEntriesQueryHandler(IRepository<FileEntry, Guid> repository)
    {
        _repository = repository;
    }

    public async Task<List<FileEntry>> HandleAsync(GetFileEntriesQuery query, CancellationToken cancellationToken = default)
    {
        return await _repository.ToListAsync(_repository.GetQueryableSet().Where(x => !x.Deleted));
    }
}
