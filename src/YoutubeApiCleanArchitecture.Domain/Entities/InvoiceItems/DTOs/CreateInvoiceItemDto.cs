﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeApiCleanArchitecture.Domain.Entities.InvoiceItems.DTOs
{
    public class CreateInvoiceItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
