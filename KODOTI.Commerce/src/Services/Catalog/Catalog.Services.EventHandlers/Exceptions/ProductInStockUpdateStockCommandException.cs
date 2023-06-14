using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Services.EventHandlers.Exceptions
{
    public class ProductInStockUpdateStockCommandException : Exception
    {
        //Inicializa el constructor de la clase que está heredando ': base(message)'
        public ProductInStockUpdateStockCommandException(string message) : base(message)
        {
                
        }
    }
}
