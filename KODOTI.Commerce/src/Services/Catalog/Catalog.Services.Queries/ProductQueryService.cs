using Catalog.Persistence.Database;
using Catalog.Services.Queries.DTOs;
using Service.Common.Collection;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Service.Common.Paging;
using Service.Common.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Services.Queries
{
    public interface IProductQueryService
    {
        Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
        Task<ProductDto> GetAsync(int id);

    }
    public class ProductQueryService : IProductQueryService
    {
        private readonly ApplicationDbContext _context;
        //Por inyeccion de dependencias ya tenemos inyectado el dbContext
        public ProductQueryService(ApplicationDbContext context)
        {
                _context = context;
        }

        public async Task<DataCollection<ProductDto>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _context.Products
                .Where(x => products == null || products.Contains(x.ProductId))
                .OrderByDescending(x => x.ProductId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDto>>();
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            return (await _context.Products.SingleAsync(x=>x.ProductId == id)).MapTo<ProductDto>();
        }
    }
}
