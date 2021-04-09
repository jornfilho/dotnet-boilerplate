using System;
using Boilerplate.Contracts.V1.Requests.Queries;

namespace Boilerplate.Services
{
    public interface IUriService
    {
        Uri GetNewDocumentUri(string uri, string idParamName, string newId);

        Uri GetPaginatedUri(PaginationQuery pagination = null);
    }
}