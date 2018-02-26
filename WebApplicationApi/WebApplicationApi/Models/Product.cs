using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationApi.Models
{
    public class Product
    {
        public System.Guid ID { get; set; }

        public int ProductCategoryId { get; set; }

        public string Name { get; set; }

        public int? Price { get; set; }

        public int? Amount { get; set; }
    }
}