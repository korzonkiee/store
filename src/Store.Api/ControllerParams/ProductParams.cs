using System;
using System.ComponentModel.DataAnnotations;

namespace Store.Api.ControllerParams
{
    public class ProductParams
    {
        [Required]
        public string Name { get; set; }
        public Guid? CategoryId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public TimeSpan DeliveryTime { get; set; }
    }
}