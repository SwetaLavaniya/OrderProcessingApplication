using System;
using System.Collections.Generic;
using System.Text;

namespace OrderProcessingApplication.Domain
{
    public class ProductDetail
    {
        public int? Amount { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}
