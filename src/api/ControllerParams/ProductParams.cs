using System;

namespace api.ControllerParams
{
    public class ProductParams
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public TimeSpan DeliveryTime { get; set; }
    }
}