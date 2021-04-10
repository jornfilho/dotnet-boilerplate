using System;
using Boilerplate.Contracts.V1.Requests.Queries;
using Microsoft.AspNetCore.WebUtilities;

namespace Boilerplate.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;
        private readonly string _currentPath;
        
        public UriService(string baseUri, string currentPath)
        {
            _baseUri = baseUri;
            _currentPath = currentPath;
        }
        
        public Uri GetNewDocumentUri(string uri, string idParamName, string newId)
        {
            if (string.IsNullOrEmpty(uri))
            {
                return null;
            }

            var newAddress = string.Concat(_baseUri, "/", uri).Replace(idParamName, newId);
            
            return new Uri(newAddress);
        }

        public Uri GetPaginatedUri(PaginationQuery pagination = null)
        {
            var uri = new Uri(string.Concat(_baseUri, _currentPath, "/"));

            if (pagination == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(uri.ToString(), "pageNumber", pagination.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pagination.PageSize.ToString());
            
            return new Uri(modifiedUri);
        }
    }
}