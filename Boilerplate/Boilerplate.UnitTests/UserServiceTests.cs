using System;
using System.Collections.Generic;
using Boilerplate.Contracts.V1.Requests.Queries;
using Boilerplate.Services;
using Xunit;
using FluentAssertions;

namespace Boilerplate.UnitTests
{
    public class UserServiceTests
    {
        private readonly UriService _sut;
        private const string BaseUri = "https://localhost:5001";
        private const string CurrentPath = "/api/v1/tests";
        private static readonly int DefaultPageSize = new PaginationQuery().GetDefaultPageSize();
        private static readonly int DefaultPageNumber = new PaginationQuery().GetDefaultPageNumber();

        public UserServiceTests()
        {
            _sut = new UriService(BaseUri, CurrentPath);
        }
        
        [Theory]
        [InlineData(null, "{id}", "1")]
        [InlineData("", "{id}", "1")]
        public void GetNewDocumentUri_ShouldReturnNullWhenUriIsNullOrEmpty(string uri, string idParamName, string newId)
        {
            // Arrange

            // Act
            var result = _sut.GetNewDocumentUri(uri, idParamName, newId);

            // Assert
            result.Should().BeNull();
        }
        
        [Theory]
        [InlineData("api/v1/tests/{id}", "{id}", "1", "api/v1/tests/1")]
        [InlineData("api/v1/tests/{documentId}", "{documentId}", "1", "api/v1/tests/1")]
        [InlineData("api/v1/tests/{document}", "{documentId}", "1", "api/v1/tests/{document}")]
        [InlineData("api/v1/tests", "{id}", "1", "api/v1/tests")]
        public void GetNewDocumentUri_ShouldFormatUriProperly(string uri, string idParamName, string newId, string expectedResult)
        {
            // Arrange
            expectedResult = string.Concat(BaseUri, "/", expectedResult);

            // Act
            var result = _sut.GetNewDocumentUri(uri, idParamName, newId);

            // Assert
            result.Should().Be(expectedResult);
        }

        [Fact]
        public void GetPaginatedUri_ShouldReturnSameUriWhenPaginationNull()
        {
            // Arrange
            var expected = new Uri(string.Concat(BaseUri, CurrentPath, "/"));

            // Act
            var uri = _sut.GetPaginatedUri();

            // Assert
            uri.Should().Be(expected);
        }
        
        [Theory]
        [MemberData(nameof(PaginationQueryData))]
        public void GetPaginatedUri_ShouldFormatUriProperly(PaginationQuery pagination, string expectedResult)
        {
            // Arrange

            // Act
            var result = _sut.GetPaginatedUri(pagination);

            // Assert
            result.Should().Be(expectedResult);
        }
        
        public static IEnumerable<object[]> PaginationQueryData =>
            new List<object[]>
            {
                new object[] {new PaginationQuery(), $"{BaseUri}{CurrentPath}/?pageNumber={DefaultPageNumber}&pageSize={DefaultPageSize}"},
                new object[] {new PaginationQuery{PageNumber = 1}, $"{BaseUri}{CurrentPath}/?pageNumber=1&pageSize={DefaultPageSize}"},
                new object[] {new PaginationQuery {PageSize = 2}, $"{BaseUri}{CurrentPath}/?pageNumber={DefaultPageNumber}&pageSize=2"},
                new object[] {new PaginationQuery {PageNumber = 3, PageSize = 4}, $"{BaseUri}{CurrentPath}/?pageNumber=3&pageSize=4"},
            };
    }
}