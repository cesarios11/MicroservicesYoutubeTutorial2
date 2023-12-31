﻿using Catalog.Services.EventHandlers.Commands;
using Catalog.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Catalog.Api.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class ProductInStockController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;      
        private readonly IMediator _mediator;

        public ProductInStockController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;            
            _mediator = mediator;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateStockCommand command) 
        {
            await _mediator.Publish(command);
            return NoContent();
        }
    }
}
