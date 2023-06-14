using Catalog.Domain;
using Catalog.Persistence.Database;
using Catalog.Services.EventHandlers.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Catalog.Services.EventHandlers
{    
    public class ProductCreateEventHandler : INotificationHandler<ProductCreateCommand>
    {
        private readonly ApplicationDbContext _context;
        public ProductCreateEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        
        //Este método handle va a desencadenar el evento y va a responder al comando 'ProductCreateCommand'
        //Solo se va a invocar el comando 'ProductCreateCommand' y el comando va a desencadenar el evento 'Handle'
        public async Task Handle(ProductCreateCommand command, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Product {
                Name = command.Name,    
                Description = command.Description,
                Price = command.Price
            });

            await _context.SaveChangesAsync();
        }
    }
}
