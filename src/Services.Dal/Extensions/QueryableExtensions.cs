﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Services.Common.Models.PagedRequest;
using Services.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dal.Extensions;

public static class QueryableExtensions
{
    public async static Task<PaginatedResult<TDto>> CreatePaginatedResultAsync<TEntity, TDto>(this IQueryable<TEntity> query, PagedRequest pagedRequest, IMapper mapper)
        where TEntity : BaseEntity
        where TDto : class
    {
        query = query.ApplyFilters(pagedRequest);

        var total = await query.CountAsync();

        query = query.Paginate(pagedRequest);

        var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

        projectionResult = projectionResult.Sort(pagedRequest);

        var listResult = await projectionResult.ToListAsync();

        return new PaginatedResult<TDto>()
        {
            Items = listResult,
            PageSize = pagedRequest.PageSize,
            PageIndex = pagedRequest.PageIndex,
            Total = total
        };
    }

    private static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagedRequest pagedRequest)
    {
        var entities = query.Skip(pagedRequest.PageIndex * pagedRequest.PageSize).Take(pagedRequest.PageSize);
        return entities;
    }

    private static IQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest pagedRequest)
    {
        if (!string.IsNullOrWhiteSpace(pagedRequest.ColumnNameForSorting))
        {
            query = query.OrderBy(pagedRequest.ColumnNameForSorting + " " + pagedRequest.SortDirection);
        }
        return query;
    }

    private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, PagedRequest pagedRequest)
    {
        var predicate = new StringBuilder();
        var requestFilters = pagedRequest.RequestFilters;
        for (int i = 0; i < requestFilters.Filters.Count; i++)
        {
            if (i > 0)
            {
                predicate.Append($" {requestFilters.LogicalOperator} ");
            }

            switch (requestFilters.Filters[i].ComparisonOperators)
            {
                case FilterComparisonOperators.StringEquals:
                    {
                        predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Equals)}(@{i})");
                        break;
                    }
                case FilterComparisonOperators.StringContains:
                    {
                        predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Contains)}(@{i})");
                        break;
                    }
                case FilterComparisonOperators.NumberEquals:
                    {
                        predicate.Append(requestFilters.Filters[i].Path + $" = @{i}");
                        break;
                    }
                case FilterComparisonOperators.NotNumberEquals:
                    {
                        predicate.Append(requestFilters.Filters[i].Path + $" != @{i}");
                        break;
                    }
            }

            //predicate.Append(requestFilters.Filters[i].Path + $".{nameof(string.Equals)}(@{i})");
        }

        if (requestFilters.Filters.Any())
        {
            var propertyValues = requestFilters.Filters.Select(filter => filter.Value).ToArray();

            query = query.Where(predicate.ToString(), propertyValues);
        }

        return query;
    }
}
