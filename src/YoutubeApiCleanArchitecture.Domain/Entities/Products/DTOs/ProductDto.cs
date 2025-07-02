using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApiCleanArchitecture.Domain.Entities.Products.DTOs
{
    public class BaseProductDto
    {
        public string Description { get; set; } = null!;
        public decimal UnitPrice { get; set; }
    }

    public class CreateProductDto : BaseProductDto { }
    public class UpdateProductDto : BaseProductDto
    {
        public Guid ProductId { get; set; }
    }
}
