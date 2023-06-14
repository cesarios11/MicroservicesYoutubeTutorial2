using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Services.EventHandlers.Commands;
using Catalog.Services.EventHandlers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Catalog.Common.Enums;

namespace Catalog.Services.EventHandlers
{
    public class ProductInStockUpdateStockEventHandler: INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateStockEventHandler> _logger;

        public ProductInStockUpdateStockEventHandler(ApplicationDbContext context, ILogger<ProductInStockUpdateStockEventHandler> logger)
        {
            _context = context; 
            _logger = logger;
        }       

        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("--- ProductInStockUpdateStockCommand started");
            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains(x.ProductId)).ToListAsync();

            _logger.LogInformation("--- Retrieve products from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductId == item.ProductId);
                if (item.Action == ProductInStockAction.Substract)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        _logger.LogError($"--- Product {entry.ProductId} - doesn't have enough stock");
                        throw new ProductInStockUpdateStockCommandException($"Product {entry.ProductId} - doesn't have enough stock");
                    }
                    entry.Stock -= item.Stock;
                    _logger.LogInformation($"--- Product {entry.ProductId} - it's stock was subtracted and its new stock is {entry.Stock}");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new ProductInStock
                        {
                            ProductId = item.ProductId
                        };

                        await _context.AddAsync(entry);
                        _logger.LogInformation($"--- New stock record was created for {entry.ProductId} because didn't exists before");
                    }
                    entry.Stock += item.Stock;
                    _logger.LogInformation($"--- Product {entry.ProductId} - it's stock was increased and its new stock is {entry.Stock}");
                }
            }

            await _context.SaveChangesAsync();

            _logger.LogInformation("--- ProductInStockUpdateStockCommand ended");
        }
    }
}
