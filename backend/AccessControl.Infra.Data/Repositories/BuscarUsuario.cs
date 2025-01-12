using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;

namespace AccessControl.Infra.Data.Repositories
{
    public class BuscarUsuario : ICustomQueryable, IQueryPaging, IQuerySort
    {
        [QueryOperator(Operator = WhereOperator.Contains)]
        public string Nome { get; set; } = string.Empty;
        public string Sistema { get; set; } = string.Empty;
        public int? Limit { get; set; } = 10;
        public int? Offset { get; set; }
        public string? Sort { get; set; }
    }
}